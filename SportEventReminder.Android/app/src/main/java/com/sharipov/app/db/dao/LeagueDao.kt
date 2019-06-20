package com.sharipov.app.db.dao

import androidx.room.*
import com.sharipov.app.db.entity.League

@Dao
interface LeagueDao {

    @Query("SELECT * FROM League")
    fun getAll(): List<League>

    @Insert
    fun insertAll(vararg league: League)

    @Delete
    fun delete(league: League)

    @Update
    fun updateLeague(vararg league: League)

    @Query("DELETE FROM League")
    fun removeAll()

}