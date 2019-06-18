package com.sharipov.app.client

import com.sharipov.app.db.entity.Area
import com.sharipov.app.db.entity.League
import com.sharipov.app.db.entity.Match
import com.sharipov.app.db.entity.Team
import io.reactivex.Single

/**
 * TODO
 */
interface IReminderClient {

    fun fetchAreas(): Single<ArrayList<Area>>

    fun fetchTeams(area: Area): Single<ArrayList<Team>>

    fun fetchLeagues(area: Area): Single<ArrayList<League>>

    fun fetchMatch(league: League): Single<ArrayList<Match>>

}