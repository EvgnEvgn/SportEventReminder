package com.sharipov.app.client

import com.sharipov.app.db.entity.Area
import com.sharipov.app.db.entity.League
import com.sharipov.app.db.entity.Match
import com.sharipov.app.db.entity.Team
import io.reactivex.Single

interface IReminderClient {

    fun fetchAreas(): Single<ArrayList<Area>>

    fun fetchTeams(): Single<ArrayList<Team>>

    fun fetchLeagues(): Single<ArrayList<League>>

    fun fetchMatch(): Single<ArrayList<Match>>

    fun saveAreas(items: ArrayList<Area>)

    fun saveTeams(items: ArrayList<Team>)

    fun saveLeagues(items: ArrayList<League>)

    fun saveMatches(items: ArrayList<Match>)

    fun clearAll()

    fun initDefaultValues()

}