package com.sharipov.app.db.dao

import androidx.room.*
import com.sharipov.app.db.entity.Area

@Dao
interface AreaDao {

    @Query("SELECT * FROM Area")
    fun getAll(): List<Area>

//    @Query("SELECT * FROM Area WHERE title LIKE :title")
//    fun findByTitle(title: String): Area

    @Insert
    fun insertAll(vararg area: Area)

    @Delete
    fun delete(area: Area)

    @Update
    fun updateArea(vararg areas: Area)

}