package com.sharipov.app.interactors

import com.sharipov.app.db.entity.Area
import com.sharipov.app.db.entity.League
import com.sharipov.app.db.entity.Match
import com.sharipov.app.db.entity.Team
import io.reactivex.Single

interface IDataInteractor {

    fun getAreas(): Single<ArrayList<Area>>

    fun getTeams(area: Area): Single<ArrayList<Team>>

    fun getLeagues(area: Area): Single<ArrayList<League>>

    fun getMatches(league: League): Single<ArrayList<Match>>

}