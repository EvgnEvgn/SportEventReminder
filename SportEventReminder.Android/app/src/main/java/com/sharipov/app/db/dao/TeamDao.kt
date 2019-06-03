package com.sharipov.app.db.dao

import androidx.room.*
import com.sharipov.app.db.entity.Team

@Dao
interface TeamDao {

    @Query("SELECT * FROM Team")
    fun getAll(): List<Team>

    @Insert
    fun insertAll(vararg teams: Team)

    @Delete
    fun delete(team: Team)

    @Update
    fun updateTeam(vararg teams: Team)

}