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

        list.add(Area(name = "The World", parentArea = ""))
        list.add(Area(name = "USA", parentArea = ""))
        list.add(Area(name = "Australia", parentArea = ""))


        return Single.just(list)
    }

    override fun getTeams(area: Area): Single<ArrayList<Team>> {
        val list = ArrayList<Team>()

        list.add(Team(name = "CSKA 1948 Sofia", shortName = "", areaId = 1, teamTag = "Bog"))
        list.add(Team(name = "Strumska Slava", shortName = "", areaId = 1, teamTag = "Bog"))
        list.add(Team(name = "Orenburg", shortName = "", areaId = 1, teamTag = "Ros"))
        list.add(Team(name = "CHFR", shortName = "", areaId = 1, teamTag = "Rum"))


        return Single.just(list)
    }

    override fun getLeagues(area: Area): Single<ArrayList<League>> {
        val list = ArrayList<League>()
        list.add(League(name = "America Cup", leagueLevel = 0, areaId = 0))
        list.add(League(name = "Argentina Cup", leagueLevel = 0, areaId = 0))
        list.add(League(name = "Russia Cup", leagueLevel = 0, areaId = 0))
        list.add(League(name = "Gorgia Cup", leagueLevel = 0, areaId = 0))

        return Single.just(list)
    }

    override fun getMatches(league: League): Single<ArrayList<Match>> {
        val list = ArrayList<Match>()

        return Single.just(list)
    }
}