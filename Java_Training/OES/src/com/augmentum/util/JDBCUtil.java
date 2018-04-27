package com.augmentum.util;

import java.lang.reflect.ParameterizedType;
import java.lang.reflect.Type;
import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.ResultSetMetaData;
import java.sql.SQLException;

import org.apache.commons.beanutils.BeanUtils;

import com.augmentum.Constants;
import com.augmentum.exception.DBException;
import com.augmentum.listener.LoadResource;

public final class JDBCUtil {

    /**
     * Get the first generic type of the class which extends this class:User
     * public class UserDaoImpl extends BaseDao<User> implements UserDao
     * @param clazz The class extends BaseDao directly
     * @param index The needed index of ParameterizedType
     * @return
     */
    @SuppressWarnings("unchecked")
    public static <T> Class<T> getSuperGeneric(Class<T> clazz, int index) {
        Type t = clazz.getGenericSuperclass();
        if (!(t instanceof ParameterizedType)) {
            clazz = (Class<T>) Object.class;
        } else {
            ParameterizedType parameterizedType = (ParameterizedType) t;
            Type[] types = parameterizedType.getActualTypeArguments();

            if (types.length == 0 || index > types.length) {
                return (Class<T>) Object.class;
            }

            if (types[index] instanceof Class) {
                return (Class<T>) types[index];
            }

        }
        return (Class<T>) Object.class;
    }

    /**
     * Get database connection
     * @return Database Connection
     */
    public static Connection getConnection() {
        Connection conn = null;
        try {
            conn = DriverManager.getConnection(LoadResource.getProperty(Constants.JDBC_URL),
                    LoadResource.getProperty(Constants.JDBC_USER),
                    LoadResource.getProperty(Constants.JDBC_PASSWORD));
        } catch (SQLException e) {
            e.printStackTrace();
            throw new DBException(MessageUtil.DB_GET_CONNECT_ERROR,
                    MessageUtil.buildMessage(MessageUtil.DB_GET_CONNECT_ERROR));
        }
        return conn;
    }

    /**
     * Fill in parameter into PreparedStatement
     * @param ps
     * @param params
     * @return
     */
    public static PreparedStatement fillParams(PreparedStatement ps, Object[] params) {
        int j = 0;
        for (int i = 0; i < params.length; i++) {
            try {
                if (params[i] != null) {
                    ps.setObject(++j, params[i]);
                }
            } catch (SQLException e) {
                e.printStackTrace();
                throw new DBException(MessageUtil.DB_FILL_PARAMETERS_ERROR,
                        MessageUtil.buildMessage(MessageUtil.DB_FILL_PARAMETERS_ERROR));
            }
        }
        return ps;
    }

    /**
     * Reflect database record into specific object
     * @param clazz The class of object who need to be reflect from database record
     * @param rs get ResultSetMetaData from ResultSet
     * @return
     */
    public static <T> T data2Obj(Class<T> clazz, ResultSet rs) {
        T obj = null;
        ResultSetMetaData rsmd = null;
        try {
            rsmd = rs.getMetaData();
            obj = clazz.newInstance();
            for (int i = 0; i < rsmd.getColumnCount(); i++) {
                String columnName = rsmd.getColumnLabel(i+1);
                Object columnVal = rs.getObject(columnName);
                try {
                    BeanUtils.setProperty(obj, columnName, columnVal);
                } catch (Exception e) {
                    e.printStackTrace();
                }
            }
        } catch (SQLException | InstantiationException | IllegalAccessException e) {
            e.printStackTrace();
            throw new DBException(MessageUtil.REFLECT_DATA2OBJ_ERROR,
                    MessageUtil.buildMessage(MessageUtil.REFLECT_DATA2OBJ_ERROR));
        }
        return obj;
    }

    /**
     * Start transcation
     * @param conn database connection
     */
    public static void startTranscation(Connection conn) {
        try {
            conn.setAutoCommit(false);
        } catch (SQLException e) {
            e.printStackTrace();
        }
    }

    /**
     * Commit Transcation if there not exists error
     * @param conn database connection
     */
    public static void commitTranscation(Connection conn) {
        try {
            conn.commit();
        } catch (SQLException e) {
            e.printStackTrace();
        }
    }

    /**
     * Rollback Transcation if there exists error
     * @param conn database connection
     */
    public static void rollbackTranscation(Connection conn) {
        try {
            conn.rollback();
        } catch (SQLException e) {
            e.printStackTrace();
        }
    }

    /**
     * Release all object of database when you not use them
     */
    public static void release(ResultSet rs, PreparedStatement ps, Connection conn) {
        if (rs != null) {
            try {
                rs.close();
            } catch (SQLException e) {
                e.printStackTrace();
                throw new DBException(MessageUtil.DB_CLOSE_ERROR,
                        MessageUtil.buildMessage(MessageUtil.DB_CLOSE_ERROR,
                                MessageUtil.JDBC_RESULTSET));
            }
        }
        if (ps != null) {
            try {
                ps.close();
            } catch (SQLException e) {
                e.printStackTrace();
                throw new DBException(MessageUtil.DB_CLOSE_ERROR,
                        MessageUtil.buildMessage(MessageUtil.DB_CLOSE_ERROR,
                                MessageUtil.JDBC_PREPAREDSTATEMENT));
            }
        }
        if (conn != null) {
            try {
                conn.close();
            } catch (SQLException e) {
                e.printStackTrace();
                throw new DBException(MessageUtil.DB_CLOSE_ERROR,
                        MessageUtil.buildMessage(MessageUtil.DB_CLOSE_ERROR,
                                MessageUtil.JDBC_CONNECTION));
            }
        }
    }

}
