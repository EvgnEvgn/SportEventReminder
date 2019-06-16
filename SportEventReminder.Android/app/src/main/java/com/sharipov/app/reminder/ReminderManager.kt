package com.sharipov.app.reminder

import android.app.AlarmManager
import android.app.PendingIntent
import android.content.Context
import android.content.Context.ALARM_SERVICE
import android.content.Intent
import com.sharipov.app.reminder.models.AlarmEvent


val REQUEST_CODE = 0

/**
 * TODO
 */
class ReminderManager {

    fun setAlarm(context: Context, alarmEvent: AlarmEvent) {
        val alarmManager = context.getSystemService(ALARM_SERVICE) as AlarmManager?
        val intent = Intent(context, ReminderService::class.java)
        0
        val pendingIntent = PendingIntent.getBroadcast(context, REQUEST_CODE, intent, PendingIntent.FLAG_UPDATE_CURRENT)
//This alarm will trigger once approximately after 1 hour and
        alarmManager!!.set(
            AlarmManager.ELAPSED_REALTIME_WAKEUP,
            alarmEvent.time,
            pendingIntent
        )
    }

}