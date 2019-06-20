package com.sharipov.app.client

import com.sharipov.app.App
import com.sharipov.app.db.entity.*
import com.sharipov.app.db.entity.MatchStatus.Scheduled
import io.reactivex.Single
import java.util.*
import kotlin.collections.ArrayList

private const val MINUTE = 1000

class ReminderClient : IReminderClient {

    private val matchDao = App.DB.matchDao()
    private val leagueDao = App.DB.leagueDao()
    private val seasonDao = App.DB.seasonDao()
    private val teamDao = App.DB.teamDao()
    private val areaDao = App.DB.areaDao()

    private val areas = arrayListOf(
        Area(id = 0, name = "The World", parentArea = ""),
        Area(id = 1, name = "USA", parentArea = ""),
        Area(id = 2, name = "Australia", parentArea = "")
    )

    private val leagues = arrayListOf(
        League(id = 0, name = "America Cup", leagueLevel = 0, areaId = 0),
        League(id = 1, name = "Argentina Cup", leagueLevel = 0, areaId = 1),
        League(id = 2, name = "Russia Cup", leagueLevel = 0, areaId = 1),
        League(id = 3, name = "Gorgia Cup", leagueLevel = 0, areaId = 2)
    )

    private val teams = arrayListOf(
        Team(id = 0, name = "CSKA", shortName = "", areaId = 1, teamTag = "Bog"),
        Team(id = 1, name = "Strumska Slava", shortName = "", areaId = 1, teamTag = "Bog"),
        Team(id = 2, name = "Orenburg", shortName = "", areaId = 1, teamTag = "Ros"),
        Team(id = 3, name = "RTS ", shortName = "", areaId = 1, teamTag = "Rum"),
        Team(id = 4, name = "Real Gastrit", shortName = "", areaId = 1, teamTag = "Rum"),
        Team(id = 5, name = "Feo", shortName = "", areaId = 1, teamTag = "Rum")
    )

    private val seasons = arrayListOf(
        Season()
    )

    private val matches = arrayListOf(
        Match(0, homeTeamId = 0, awayTeamId = 1, leagueId = 0, status = Scheduled, startDate = time() + 1 * MINUTE),
        Match(1, homeTeamId = 0, awayTeamId = 2, leagueId = 0, status = Scheduled, startDate = time() + 3 * MINUTE),
        Match(2, homeTeamId = 1, awayTeamId = 2, leagueId = 0, status = Scheduled, startDate = time() + 6 * MINUTE),
        Match(3, homeTeamId = 2, awayTeamId = 3, leagueId = 0, status = Scheduled, startDate = time() + 5 * MINUTE),

        Match(4, homeTeamId = 3, awayTeamId = 0, leagueId = 1, status = Scheduled, startDate = time() + 10 * MINUTE),
        Match(5, homeTeamId = 3, awayTeamId = 4, leagueId = 1, status = Scheduled, startDate = time() + 33 * MINUTE),
        Match(6, homeTeamId = 4, awayTeamId = 0, leagueId = 1, status = Scheduled, startDate = time() + 35 * MINUTE),
        Match(8, homeTeamId = 4, awayTeamId = 1, leagueId = 1, status = Scheduled, startDate = time() + 33 * MINUTE),
        Match(9, homeTeamId = 4, awayTeamId = 2, leagueId = 1, status = Scheduled, startDate = time() + 40 * MINUTE)
    )

    override fun clearAll() {
        matchDao.removeAll()
        leagueDao.removeAll()
        seasonDao.removeAll()
        teamDao.removeAll()
        areaDao.removeAll()
    }

    override fun initDefaultValues() {
        areas.forEach { areaDao.insertAll(it) }
        leagues.forEach { leagueDao.insertAll(it) }
        teams.forEach { teamDao.insertAll(it) }
        seasons.forEach { seasonDao.insertAll(it) }
        matches.forEach { matchDao.insertAll(it) }
    }

    override fun fetchAreas() = areaDao.getAll().toSingle()

    override fun fetchTeams() = teamDao.getAll().toSingle()

    override fun fetchLeagues() = leagueDao.getAll().toSingle()

    override fun fetchMatch() = matchDao.getAll().toSingle()

    private fun <T> List<T>.toSingle() = Single.just(ArrayList(this))

    private fun time() = Calendar.getInstance().timeInMillis
}