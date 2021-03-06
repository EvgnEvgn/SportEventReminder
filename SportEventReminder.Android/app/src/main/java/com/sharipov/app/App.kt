package com.sharipov.app

import android.app.Application
import androidx.room.Room
import com.sharipov.app.db.AppDatabase
import com.sharipov.app.reminder.ReminderManager

class App : Application() {

    companion object {
        const val DB_NAME = "database"
        lateinit var DB: AppDatabase
    }

    override fun onCreate() {
        super.onCreate()
        initDb()
    }

    private fun initDb() {
        DB = Room.databaseBuilder(applicationContext, AppDatabase::class.java, DB_NAME)
            .allowMainThreadQueries()
            .build()

        initAlarm()
    }

    /**
    1 minute
     */
    private fun initAlarm() {
        ReminderManager(this).setRepeatingAlarm()
    }
}