package com.sharipov.app.teamsScreen.viewModel

import android.app.Application
import androidx.lifecycle.LiveData
import androidx.lifecycle.MutableLiveData
import com.sharipov.app.db.entity.Team
import com.sharipov.app.di.Injector
import com.sharipov.app.utils.CustomViewModel
import io.reactivex.android.schedulers.AndroidSchedulers
import io.reactivex.schedulers.Schedulers

class TeamsViewModel(app: Application) : CustomViewModel(app) {

    private val mutableLiveData = MutableLiveData<ArrayList<Team>>()
    private val list = ArrayList<Team>()

    fun getTeamList(): LiveData<ArrayList<Team>> = mutableLiveData

    fun setOnSelectListener(team: Team, isChecked: Boolean) {
        team.isWatched = isChecked
        list.forEach { if (it.id == team.id) it.isWatched = team.isWatched }
        interactor.saveTeams(list)
    }

    init {
        compositeDisposable.add(
            Injector.dataInteractor.getTeams()
                .observeOn(AndroidSchedulers.mainThread())
                .subscribeOn(Schedulers.io())
                .subscribe({
                    setItems(it)
                }, {
                    setItems(ArrayList())
                })
        )
    }

    private fun setItems(it: ArrayList<Team>) {
        list.clear()
        list.addAll(it)
        mutableLiveData.postValue(it)
    }
}