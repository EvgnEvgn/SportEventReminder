package com.sharipov.app.matchScreen

import android.app.Application
import androidx.lifecycle.LiveData
import androidx.lifecycle.MutableLiveData
import com.sharipov.app.db.entity.Match
import com.sharipov.app.di.Injector
import com.sharipov.app.reminder.ReminderManager
import com.sharipov.app.reminder.models.AlarmEvent
import com.sharipov.app.utils.CustomViewModel
import io.reactivex.android.schedulers.AndroidSchedulers
import io.reactivex.schedulers.Schedulers
import java.util.*

class MatchViewModel(application: Application) : CustomViewModel(application) {

    private val reminderManager = ReminderManager(application)

    private val mutableMatchLiveData = MutableLiveData<ArrayList<Match>>()

    fun startAlarmOnClick() {
        val alarmEvent = AlarmEvent(Date().time + 1000 * 10, "")//FIXME
        reminderManager.setAlarm(alarmEvent)
    }

    fun getMatchList(): LiveData<ArrayList<Match>> = mutableMatchLiveData

    init {
        compositeDisposable.add(
            Injector.dataInteractor.getMatches()
                .observeOn(AndroidSchedulers.mainThread())
                .subscribeOn(Schedulers.io())
                .subscribe({
                    mutableMatchLiveData.postValue(it)
                }, {
                    mutableMatchLiveData.postValue(ArrayList())
                })
        )
    }
}