package com.sharipov.app.reminder

import android.app.AlarmManager
import android.app.PendingIntent
import android.content.Context
import android.content.Context.ALARM_SERVICE
import android.content.Intent
import com.google.gson.Gson
import com.sharipov.app.reminder.models.AlarmEvent


const val REQUEST_CODE = 0

class ReminderManager(private val context: Context) {

    fun setAlarm(alarmEvent: AlarmEvent) {
        val alarmManager = context.getSystemService(ALARM_SERVICE) as AlarmManager?
        val intent = Intent(context, ReminderService::class.java)
        intent.putExtra(EXTRA_ALARM_EVENT, Gson().toJson(alarmEvent))

        val pendingIntent = PendingIntent.getService(context, REQUEST_CODE, intent, PendingIntent.FLAG_ONE_SHOT)

        alarmManager!!.set(
            AlarmManager.RTC_WAKEUP,
            alarmEvent.time ,
            pendingIntent
        )
    }
}