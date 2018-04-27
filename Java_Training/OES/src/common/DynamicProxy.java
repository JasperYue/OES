package common;

import java.lang.reflect.InvocationHandler;
import java.lang.reflect.InvocationTargetException;
import java.lang.reflect.Method;
import java.sql.Connection;
import java.util.ArrayList;
import java.util.List;

import com.augmentum.exception.ParamException;
import com.augmentum.util.JDBCUtil;

public class DynamicProxy implements InvocationHandler{

    private Object target;
    private List<String> strList = new ArrayList<>();

    public DynamicProxy(Object target) {
        this.target = target;
        strList.add("addQuestion");
        strList.add("editQuestion");
        strList.add("addExam");
    }

    @Override
    public Object invoke(Object proxy, Method method, Object[] args) throws Throwable {
        Object result = null;
           //Pass 1: Do before.
        ConnectionHolder connectionHolder = WebContext.getInstance().getConnectionHolder();
        boolean needMyClose = false;
        boolean isCommitOrRollbackTran = false;

        if (connectionHolder == null) {
            Connection conn = JDBCUtil.getConnection();
            connectionHolder = new ConnectionHolder();
            connectionHolder.setConn(conn);
            if (strList.contains(method.getName())) {
                JDBCUtil.startTranscation(conn);
                connectionHolder.setStartTran(true);
                isCommitOrRollbackTran = true;
            }
            WebContext.getInstance().bindConnectionHolder(connectionHolder);
            needMyClose = true;
        } else {
            if (strList.contains(method.getName())) {
                if (!connectionHolder.isStartTran()) {
                    connectionHolder.setStartTran(true);
                    JDBCUtil.startTranscation(connectionHolder.getConn());
                    isCommitOrRollbackTran = true;
                }
            }
        }

        try {
            result = method.invoke(target, args);
            //Pass 2: Do after.
            if (strList.contains(method.getName())) {
                if (isCommitOrRollbackTran) {
                    JDBCUtil.commitTranscation(connectionHolder.getConn());
                }

            }
        } catch (InvocationTargetException e) {
            if (!(e.getTargetException() instanceof ParamException)) {
                if (strList.contains(method.getName())) {
                    if (isCommitOrRollbackTran) {
                        JDBCUtil.rollbackTranscation(connectionHolder.getConn());
                    }
                }
            }
            throw e.getTargetException();
        } finally {
            if (needMyClose) {
                connectionHolder = WebContext.getInstance().getConnectionHolder();
                JDBCUtil.release(null, null, connectionHolder.getConn());
                WebContext.getInstance().removeConnectionHolder();
                connectionHolder.setConn(null);
                connectionHolder = null;
            }
        }

        return result;
    }

}
