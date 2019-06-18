package com.sharipov.app.baseScreen

import android.app.Application
import androidx.lifecycle.AndroidViewModel
import com.sharipov.app.reminder.ReminderManager
import com.sharipov.app.reminder.models.AlarmEvent
import java.util.*

class BaseFragmentViewModel(application: Application) : AndroidViewModel(application) {

    private val reminderManager = ReminderManager(application)

    companion object {
        const val TAG = "sharipov"
    }

    fun startAlarmOnClick() {
        val alarmEvent = AlarmEvent(Date().time + 1000 * 10, "Daga kotowary")
        reminderManager.setAlarm(alarmEvent)
    }
}