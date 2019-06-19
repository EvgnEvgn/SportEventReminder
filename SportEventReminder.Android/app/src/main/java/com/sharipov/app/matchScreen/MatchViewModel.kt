package com.sharipov.app.matchScreen

import android.app.Application
import androidx.lifecycle.AndroidViewModel
import androidx.lifecycle.LiveData
import androidx.lifecycle.MutableLiveData
import com.sharipov.app.reminder.ReminderManager
import com.sharipov.app.reminder.models.AlarmEvent
import java.util.*

class MatchViewModel(application: Application) : AndroidViewModel(application) {

    private val reminderManager = ReminderManager(application)

    private val mutableMatchLiveData = MutableLiveData<ArrayList<String>>()

    fun startAlarmOnClick() {
        val alarmEvent = AlarmEvent(Date().time + 1000 * 10, "")//FIXME
        reminderManager.setAlarm(alarmEvent)
    }

    fun getMatchList(): LiveData<ArrayList<String>> = mutableMatchLiveData

    init {
        val list = ArrayList<String>()

        list.add("CSKA 1948 Sofia VS Orenburg 20/06 12.12")
        list.add("Strumska Slava VS CHFR 21/06 21.00")

        mutableMatchLiveData.postValue(list)
    }
}