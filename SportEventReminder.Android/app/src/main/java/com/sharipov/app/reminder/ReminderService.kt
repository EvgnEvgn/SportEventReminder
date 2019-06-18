package com.sharipov.app.reminder

import android.app.IntentService
import android.content.Intent
import com.google.gson.Gson
import com.sharipov.app.NotificationCreator
import com.sharipov.app.reminder.models.AlarmEvent

const val EXTRA_ALARM_EVENT = "alarmEvent"

class ReminderService : IntentService("ReminderService") {

    override fun onHandleIntent(intent: Intent?) {
        val alarmEvent = Gson().fromJson(intent?.getStringExtra(EXTRA_ALARM_EVENT), AlarmEvent::class.java)
        val notificationCreator = NotificationCreator()
        notificationCreator.create(baseContext, "Sport Reminder", alarmEvent.text)
    }
}
