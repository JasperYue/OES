package com.augmentum.dao;

import java.util.List;


public interface Dao<T> {

    /**
     * Insert a record with the value of Primary key.
     * @param sql DQL statement
     * @param params Parameter needed to fill in sql
     * @return The auto generated value of primary key
     */
    long insert(String sql, Object... params);

    /**
     * Update, Delete, Insert data
     * @param sql DML statement
     * @param params Parameter needed to fill in sql
     * @return the number of affected rows
     */
    int update(String sql, Object... params);

    /**
     * Batch handle data
     * @param sql DML statement
     * @param params Parameter needed to fill in sql
     * @return the number of affected rows
     */
    int batch(String sql, Object[]...params);

    /**
     * Query object on the specific condition
     * @param sql DQL statement
     * @param params Parameter needed to fill in sql
     * @return The object meets the condition
     */
    T getObject(String sql, Object... params);

    /**
     * Query an object list on the specific condition
     * @param sql DQL statement
     * @param params Parameter needed to fill in sql
     * @return The object list meets the condition
     */
    List<T> getObjList(String sql, Object... params);

    /**
     * Query a single value on the specific condition
     * SELECT COUNT(*) FROM table_name
     * @param sql DQL statement
     * @param params Parameter needed to fill in sql
     * @return The single value meets the condition
     */
    <V> V getSingleVal(String sql, Object... params);

}
