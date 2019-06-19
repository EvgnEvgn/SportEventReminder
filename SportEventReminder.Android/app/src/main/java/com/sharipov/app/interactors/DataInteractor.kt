package com.sharipov.app.interactors

import com.sharipov.app.client.ReminderClient
import com.sharipov.app.db.entity.Area
import com.sharipov.app.db.entity.League
import com.sharipov.app.db.entity.Match
import com.sharipov.app.db.entity.Team
import io.reactivex.Single

class DataInteractor : IDataInteractor {

    private val reminderClient: ReminderClient

    constructor(reminderClient: ReminderClient) {
        this.reminderClient = reminderClient
    }

    override fun getAreas(): Single<ArrayList<Area>> {
        val list = ArrayList<Area>()

        list.add(Area(name = "", parentArea = ""))
        list.add(Area(name = "", parentArea = ""))
        list.add(Area(name = "", parentArea = ""))


        return Single.just(list)
    }

    override fun getTeams(area: Area): Single<ArrayList<Team>> {
        val list = ArrayList<Team>()

        list.add(Team(name = "", shortName = "", areaId = 0, teamTag = ""))


        return Single.just(list)
    }

    override fun getLeagues(area: Area): Single<ArrayList<League>> {
        val list = ArrayList<League>()

        return Single.just(list)
    }

    override fun getMatches(league: League): Single<ArrayList<Match>> {
        val list = ArrayList<Match>()

        return Single.just(list)
    }
}