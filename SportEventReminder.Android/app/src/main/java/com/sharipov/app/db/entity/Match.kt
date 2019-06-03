package com.sharipov.app.db.entity

import androidx.annotation.NonNull
import androidx.room.ColumnInfo
import androidx.room.Entity
import androidx.room.ForeignKey
import androidx.room.PrimaryKey

@Entity(
    tableName = "Match",
    foreignKeys = [
        ForeignKey(
            entity = League::class, parentColumns = ["id"],
            childColumns = ["LeagueId"], onDelete = ForeignKey.NO_ACTION
        ),
        ForeignKey(
            entity = Team::class, parentColumns = ["id"],
            childColumns = ["HomeTeamId"], onDelete = ForeignKey.NO_ACTION
        ),
        ForeignKey(
            entity = Team::class, parentColumns = ["id"],
            childColumns = ["AwayTeamId"], onDelete = ForeignKey.NO_ACTION
        )
    ]
)
class Match(

    @NonNull @PrimaryKey(autoGenerate = true) var id: Long? = null,

    @ColumnInfo(name = "LeagueId") var leagueId: Int?,

    @ColumnInfo(name = "StartDate") var startDate: Long,

    @ColumnInfo(name = "HomeTeamId") var homeTeamId: Long?,

    @ColumnInfo(name = "AwayTeamId") var awayTeamId: Long?,

    @ColumnInfo(name = "Status") var status: Int

)