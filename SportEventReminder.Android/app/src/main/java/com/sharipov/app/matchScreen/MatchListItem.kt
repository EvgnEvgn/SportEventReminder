package com.sharipov.app.matchScreen

import com.sharipov.app.db.entity.Match

class MatchListItem(val match: Match) {

    var teamHome: String = ""
    var teamAway: String = ""
    var areaString: String = ""
    var leagueString: String = ""
}