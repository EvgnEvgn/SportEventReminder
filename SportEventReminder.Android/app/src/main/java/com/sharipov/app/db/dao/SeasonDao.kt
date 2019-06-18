package com.sharipov.app.db.dao

import androidx.room.*
import com.sharipov.app.db.entity.Season

@Dao
interface SeasonDao {

    @Query("SELECT * FROM Season")
    fun getAll(): List<Season>

    @Insert
    fun insertAll(vararg seasons: Season)

    @Delete
    fun delete(season: Season)

    @Update
    fun updateSeason(vararg seasons: Season)

}