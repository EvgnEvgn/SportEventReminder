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

    private val mutableLiveData = MutableLiveData<ArrayList<Match>>()

    private val list = ArrayList<Match>()

    fun startAlarmOnClick() {
        val alarmEvent = AlarmEvent(Date().time + 1000 * 10, "")//FIXME
        reminderManager.setAlarm(alarmEvent)
    }

    fun getMatchList(): LiveData<ArrayList<Match>> = mutableLiveData

    fun setOnSelectListener(match: Match, checked: Boolean) {
        match.isWatched = checked
        list.forEach { if (it.id == match.id) it.isWatched = match.isWatched }
        interactor.saveMatches(list)
    }

    init {
        compositeDisposable.add(
            Injector.dataInteractor.getMatches()
                .observeOn(AndroidSchedulers.mainThread())
                .subscribeOn(Schedulers.io())
                .subscribe({
                    setItems(it)
                }, {
                    setItems(ArrayList())
                })
        )
    }

    private fun setItems(it: ArrayList<Match>) {
        list.clear()
        list.addAll(it)
        mutableLiveData.postValue(it)
    }
}