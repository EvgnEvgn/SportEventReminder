package com.sharipov.app.db.entity

import androidx.annotation.NonNull
import androidx.room.ColumnInfo
import androidx.room.Entity
import androidx.room.ForeignKey
import androidx.room.PrimaryKey


/**
 * TODO
 */
@Entity(
    tableName = "League",
    foreignKeys = [ForeignKey(
        entity = Area::class, parentColumns = ["id"],
        childColumns = ["areaId"], onDelete = ForeignKey.CASCADE
    )]
)
class League(

    @NonNull @PrimaryKey(autoGenerate = true) var id: Long? = null,

    @ColumnInfo(name = "Name") var name: String,

    @ColumnInfo(name = "LeagueLevel") var leagueLevel: Int,

    @ColumnInfo(name = "areaId") var areaId: Int?

)