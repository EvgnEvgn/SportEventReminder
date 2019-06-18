package com.sharipov.app.client

import com.sharipov.app.db.entity.Area
import com.sharipov.app.db.entity.League
import com.sharipov.app.db.entity.Match
import com.sharipov.app.db.entity.Team
import io.reactivex.Single
import retrofit2.Retrofit


class ReminderClient(retrofit: Retrofit) : IReminderClient {

    init {

    }

    override fun fetchAreas(): Single<ArrayList<Area>> {
        TODO()
    }

    override fun fetchTeams(area: Area): Single<ArrayList<Team>> {
        TODO()
    }

    override fun fetchLeagues(area: Area): Single<ArrayList<League>> {
        TODO()
    }

    override fun fetchMatch(league: League): Single<ArrayList<Match>> {
        TODO()
    }
}