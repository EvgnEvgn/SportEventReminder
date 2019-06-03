package com.sharipov.app

import android.app.Application
import androidx.room.Room
import com.sharipov.app.db.AppDatabase


/**
 * TODO
 */
class App : Application() {

    companion object {
        const val DB_NAME = "database"
        lateinit var db: AppDatabase
    }

    override fun onCreate() {
        super.onCreate()
        initDb()
    }

    private fun initDb() {
        db = Room.databaseBuilder(applicationContext, AppDatabase::class.java, DB_NAME)
            .allowMainThreadQueries()
            .build()
    }
}