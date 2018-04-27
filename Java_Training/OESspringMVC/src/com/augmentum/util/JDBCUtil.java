package com.augmentum.util;

import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.ResultSetMetaData;
import java.sql.SQLException;

import org.apache.commons.beanutils.BeanUtils;

import com.augmentum.exception.DBException;

public final class JDBCUtil {

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
            throw new DBException(MessageUtil.REFLECT_DATA2OBJ_ERROR,
                    MessageUtil.buildMessage(MessageUtil.REFLECT_DATA2OBJ_ERROR));
        }
        return obj;
    }

}
