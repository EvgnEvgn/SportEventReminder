package com.sharipov.app.matchScreen

import android.app.Application
import androidx.lifecycle.LiveData
import androidx.lifecycle.MutableLiveData
import com.sharipov.app.db.entity.Area
import com.sharipov.app.db.entity.League
import com.sharipov.app.db.entity.Match
import com.sharipov.app.db.entity.Team
import com.sharipov.app.reminder.ReminderManager
import com.sharipov.app.utils.CustomViewModel
import io.reactivex.Single
import io.reactivex.android.schedulers.AndroidSchedulers
import io.reactivex.functions.Function4
import io.reactivex.schedulers.Schedulers

class MatchViewModel(application: Application) : CustomViewModel(application) {

    private val reminderManager = ReminderManager(application)

    private val mutableLiveData = MutableLiveData<ArrayList<MatchListItem>>()

    private val list = ArrayList<MatchListItem>()

//    fun startAlarmOnClick() {
//        val alarmEvent = AlarmEvent(Date().time + 1000 * 10, "")//FIXME
//        reminderManager.setAlarm(alarmEvent)
//    }

    fun getMatchList(): LiveData<ArrayList<MatchListItem>> = mutableLiveData

    fun setOnSelectListener(match: MatchListItem, checked: Boolean) {
        match.match.isWatched = checked
        list.forEach { if (it.match.id == match.match.id) it.match.isWatched = match.match.isWatched }
        interactor.saveMatches(ArrayList(list.map { it.match }))
    }

    init {
        compositeDisposable.add(
            Single.zip(
                interactor.getAreas(),
                interactor.getTeams(),
                interactor.getLeagues(),
                interactor.getMatches(),
                Function4<ArrayList<Area>, ArrayList<Team>, ArrayList<League>, ArrayList<Match>, ArrayList<MatchListItem>>
                { areas, teams, leagues, matches ->
                    list.clear()
                    matches.forEach { match ->
                        val matchListItem = MatchListItem(match)
                        teams.forEach {
                            if (match.homeTeamId == it.id) {
                                matchListItem.teamHome = it.name!!
                            }

                            if (match.awayTeamId == it.id) {
                                matchListItem.teamAway = it.name!!
                            }

                        }

                        leagues.forEach {
                            if (match.leagueId == it.id!!.toInt()) {
                                matchListItem.leagueString = it.name
                            }
                        }
                        list.add(matchListItem)
                    }

                    return@Function4 list
                })
                .observeOn(AndroidSchedulers.mainThread())
                .subscribeOn(Schedulers.io())
                .subscribe({
                    mutableLiveData.postValue(list)
                }, {
                    mutableLiveData.postValue(list)
                })
        )
    }
}