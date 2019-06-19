package com.sharipov.app.baseScreen

import android.app.Application
import androidx.lifecycle.AndroidViewModel
import com.sharipov.app.reminder.ReminderManager
import com.sharipov.app.reminder.models.AlarmEvent
import java.util.*

class BaseFragmentViewModel(application: Application) : AndroidViewModel(application) {

    private val reminderManager = ReminderManager(application)

    fun startAlarmOnClick() {
        val alarmEvent = AlarmEvent(Date().time + 1000 * 10, "CSKA 1948 Sofia game NOW!")//FIXME
        reminderManager.setAlarm(alarmEvent)
    }
}