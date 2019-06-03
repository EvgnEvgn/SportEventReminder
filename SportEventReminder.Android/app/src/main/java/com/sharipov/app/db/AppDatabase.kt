package com.sharipov.app.db

import androidx.room.Database
import androidx.room.RoomDatabase
import com.sharipov.app.db.dao.*
import com.sharipov.app.db.entity.*

@Database(entities = [Area::class, League::class, Match::class, Season::class, Team::class], version = 1)
abstract class AppDatabase : RoomDatabase() {

    abstract fun areaDao(): AreaDao

    abstract fun leagueDao(): LeagueDao

    abstract fun matchDao(): MatchDao

    abstract fun seasonDao(): SeasonDao

    abstract fun teamDao(): TeamDao


}