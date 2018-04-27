package com.augmentum.dao.impl;

import java.sql.Connection;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Statement;
import java.util.ArrayList;
import java.util.List;

import com.augmentum.Constants;
import com.augmentum.dao.Dao;
import com.augmentum.exception.DBException;
import com.augmentum.util.JDBCUtil;
import com.augmentum.util.MessageUtil;
import common.ConnectionHolder;
import common.WebContext;

/**
 * The implementation of basic database's method based on JDBC template
 * @author Jasper.yue
 *
 * @param <T>
 */
public class BaseDao<T> implements Dao<T> {

    /** subclass' parameterizedType */
    private Class<T> clazz = null;

    @SuppressWarnings("unchecked")
    public BaseDao() {
        clazz = (Class<T>) JDBCUtil.getSuperGeneric(this.getClass(), 0);
    }

    @Override
    public int update(String sql, Object...params) {
        Connection conn = null;
        PreparedStatement ps = null;

        /** the number of affected rows */
        int size = 0;
        boolean needMyClose = false;

        try {
            ConnectionHolder connectionHolder = WebContext.getInstance().getConnectionHolder();

            if (connectionHolder != null) {
                conn = connectionHolder.getConn();
            }
            if (conn == null) {
                conn = JDBCUtil.getConnection();
                needMyClose = true;
            }

            System.out.println("conn:update" + conn);
            ps = conn.prepareStatement(sql);
            ps = JDBCUtil.fillParams(ps, params);
            size = ps.executeUpdate();
        } catch (SQLException e) {
            e.printStackTrace();
            throw new DBException(MessageUtil.DB_UPDATE_OBJECT_ERROR,
                    MessageUtil.buildMessage(MessageUtil.DB_UPDATE_OBJECT_ERROR));
        } finally {
            JDBCUtil.release(null, ps, null);
            if (needMyClose) {
                JDBCUtil.release(null, null, conn);
            }
        }
        return size;
    }

    @Override
    public T getObject(String sql, Object...params) {
        List<T> objList = getObjList(sql, params);
        if (objList.size() == Constants.STATUS_ZERO) {
            return null;
        }
        return objList.get(Constants.STATUS_ZERO);
    }

    @Override
    public List<T> getObjList(String sql, Object... params) {
        Connection conn = null;
        PreparedStatement ps = null;
        ResultSet rs = null;

        /** Initial the objList */
        List<T> objList = new ArrayList<>();
        boolean needMyClose = false;

        try {
            ConnectionHolder connectionHolder = WebContext.getInstance().getConnectionHolder();

            if (connectionHolder != null) {
                conn = connectionHolder.getConn();
            }
            if (conn == null) {
                conn = JDBCUtil.getConnection();
                needMyClose = true;
            }

            ps = conn.prepareStatement(sql);
            ps = JDBCUtil.fillParams(ps, params);
            rs = ps.executeQuery();

            T obj = null;
            while (rs.next()) {
                obj = JDBCUtil.data2Obj(clazz, rs);
                objList.add(obj);
            }
        } catch (SQLException e) {
            e.printStackTrace();
            throw new DBException(MessageUtil.DB_QUERY_OBJECTLIST_ERROR,
                    MessageUtil.buildMessage(MessageUtil.DB_QUERY_OBJECTLIST_ERROR));
        } finally {
            JDBCUtil.release(rs, ps, null);
            if (needMyClose) {
                JDBCUtil.release(null, null, conn);
            }
        }
        return objList;
    }

    @SuppressWarnings("unchecked")
    @Override
    public <V> V getSingleVal(String sql, Object... params) {
        Connection conn = null;
        PreparedStatement ps = null;
        ResultSet rs = null;

        /** The single value with any type */
        V val = null;
        boolean needMyClose = false;

        try {
            ConnectionHolder connectionHolder = WebContext.getInstance().getConnectionHolder();

            if (connectionHolder != null) {
                conn = connectionHolder.getConn();
            }
            if (conn == null) {
                conn = JDBCUtil.getConnection();
                needMyClose = true;
            }
            ps = conn.prepareStatement(sql);
            ps = JDBCUtil.fillParams(ps, params);
            rs = ps.executeQuery();

            if (rs.next()) {
                val = (V) rs.getObject(1);
            }
        } catch (SQLException e) {
            e.printStackTrace();
            throw new DBException(MessageUtil.DB_QUERY_SINGLEVALUE_ERROR,
                    MessageUtil.buildMessage(MessageUtil.DB_QUERY_SINGLEVALUE_ERROR));
        } finally {
            JDBCUtil.release(rs, ps, null);
            if (needMyClose) {
                JDBCUtil.release(null, null, conn);
            }
        }
        return val;
    }

    @Override
    public long insert(String sql, Object... params) {
        Connection conn = null;
        PreparedStatement ps = null;
        ResultSet rs = null;

        /** Generated Keys */
        long key = -1;
        boolean needMyClose = false;

        try {
            ConnectionHolder connectionHolder = WebContext.getInstance().getConnectionHolder();

            if (connectionHolder != null) {
                conn = connectionHolder.getConn();
            }
            if (conn == null) {
                conn = JDBCUtil.getConnection();
                needMyClose = true;
            }
            System.out.println("conn:insert" + conn);
            ps = conn.prepareStatement(sql, Statement.RETURN_GENERATED_KEYS);
            ps = JDBCUtil.fillParams(ps, params);
            ps.executeUpdate();

            rs = ps.getGeneratedKeys();
            if (rs.next()) {
                key = rs.getLong(1);
            }
        } catch (SQLException e) {
            e.printStackTrace();
            throw new DBException(MessageUtil.DB_RETURN_GENERATEKEY_ERROR,
                    MessageUtil.buildMessage(MessageUtil.DB_RETURN_GENERATEKEY_ERROR));
        } finally {
            JDBCUtil.release(rs, ps, null);
            if (needMyClose) {
                JDBCUtil.release(null, null, conn);
            }
        }
        return key;
    }

    @Override
    public int batch(String sql, Object[]... params) {
        Connection conn = null;
        PreparedStatement ps = null;
        int[] result = new int[params.length];
        int size = 0;
        boolean needMyClose = false;

        try {
            ConnectionHolder connectionHolder = WebContext.getInstance().getConnectionHolder();

            if (connectionHolder != null) {
                conn = connectionHolder.getConn();
            }
            if (conn == null) {
                conn = JDBCUtil.getConnection();
                needMyClose = true;
            }
            ps = conn.prepareStatement(sql);
            for (int i = 0; i < params.length; i++) {
                ps.setObject(1, params[i][0]);
                ps.addBatch();
            }

            result = ps.executeBatch();
        } catch (SQLException e) {
            e.printStackTrace();
            throw new DBException(MessageUtil.DB_BATCH_ERROR,
                    MessageUtil.buildMessage(MessageUtil.DB_BATCH_ERROR));
        } finally {
            JDBCUtil.release(null, ps, null);
            if (needMyClose) {
                JDBCUtil.release(null, null, conn);
            }
        }
        for (int i = 0; i < result.length; i++) {
            size += result[i];
        }

        return size;
    }

}
