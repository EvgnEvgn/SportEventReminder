package com.sharipov.app.reminder

import android.app.IntentService
import android.content.Context
import android.content.Intent
import com.google.gson.Gson
import com.sharipov.app.reminder.models.AlarmEvent

private const val ACTION_REMINDER = "com.sharipov.app.reminder.action.FOO"
private const val EXTRA_REMINDER = "com.sharipov.app.reminder.extra.PARAM1"

class ReminderService : IntentService("ReminderService") {

    override fun onHandleIntent(intent: Intent?) {
        when (intent?.action) {
            ACTION_REMINDER -> {
                val json = intent.getStringExtra(EXTRA_REMINDER)
                val alarmEvent = Gson().fromJson(json, AlarmEvent::class.java)
            }
        }
    }

    companion object {
        @JvmStatic
        fun start(context: Context, alarmEvent: AlarmEvent) {
            val intent = Intent(context, ReminderService::class.java).apply {
                action = ACTION_REMINDER
                putExtra(EXTRA_REMINDER, Gson().toJson(alarmEvent))
            }
            context.startService(intent)
        }
    }
}
