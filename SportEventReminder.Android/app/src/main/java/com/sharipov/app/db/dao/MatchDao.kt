package com.sharipov.app.db.dao

import androidx.room.*
import com.sharipov.app.db.entity.Match

@Dao
interface MatchDao {

    @Query("SELECT * FROM `Match`")
    fun getAll(): List<Match>

    @Insert
    fun insertAll(vararg match: Match)

    @Delete
    fun delete(match: Match)

    @Update
    fun updateMatch(vararg matches: Match)

    @Query("DELETE FROM `Match`")
    fun removeAll()

}