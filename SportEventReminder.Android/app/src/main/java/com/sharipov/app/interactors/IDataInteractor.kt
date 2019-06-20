package com.sharipov.app.interactors

import com.sharipov.app.db.entity.Area
import com.sharipov.app.db.entity.League
import com.sharipov.app.db.entity.Match
import com.sharipov.app.db.entity.Team
import io.reactivex.Single

interface IDataInteractor {

    fun getAreas(): Single<ArrayList<Area>>

    fun getTeams(): Single<ArrayList<Team>>

    fun getLeagues(): Single<ArrayList<League>>

    fun getMatches(): Single<ArrayList<Match>>

    fun saveAreas(items: ArrayList<Area>)

    fun saveTeams(items: ArrayList<Team>)

    fun saveLeagues(items: ArrayList<League>)

    fun saveMatches(items: ArrayList<Match>)

}