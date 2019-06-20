package com.sharipov.app.db.dao

import androidx.room.*
import com.sharipov.app.db.entity.Area

@Dao
interface AreaDao {

    @Query("SELECT * FROM Area")
    fun getAll(): List<Area>

    @Insert
    fun insertAll(vararg area: Area)

    @Delete
    fun delete(area: Area)

    @Update
    fun updateArea(vararg areas: Area)

    @Query("DELETE FROM Area")
    fun removeAll()

}