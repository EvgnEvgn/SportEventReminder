package com.sharipov.app.db.entity

import androidx.room.ColumnInfo
import androidx.room.Entity
import androidx.room.ForeignKey
import androidx.room.PrimaryKey
import java.util.*

@Entity(
    tableName = "Match",
    foreignKeys = [
        ForeignKey(
            entity = Team::class, parentColumns = ["id", "id"],
            childColumns = ["HomeTeamId", "AwayTeamId"], onDelete = ForeignKey.CASCADE
        ),
        ForeignKey(
            entity = League::class, parentColumns = ["id"],
            childColumns = ["LeagueId"], onDelete = ForeignKey.CASCADE
        )
    ]
)
class Match(

    @PrimaryKey(autoGenerate = true) var id: Long? = null,

    @ColumnInfo(name = "LeagueId") var leagueId: Int?,

    @ColumnInfo(name = "StartDate") var startDate: Long,

    @ColumnInfo(name = "HomeTeamId") var homeTeamId: Int?,

    @ColumnInfo(name = "AwayTeamId") var awayTeamId: Int?,

    @ColumnInfo(name = "Status") var status: Int

)