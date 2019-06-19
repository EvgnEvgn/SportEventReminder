package com.sharipov.app.db.entity

import androidx.annotation.NonNull
import androidx.room.ColumnInfo
import androidx.room.Entity
import androidx.room.PrimaryKey

@Entity(tableName = "Team")
class Team(

    @NonNull
    @PrimaryKey(autoGenerate = true)
    @ColumnInfo(name = "id", index = true)
    var id: Long = 0,

    @ColumnInfo(name = "AreaId") var areaId: Int?,

    @ColumnInfo(name = "ShortName") var shortName: String?,

    @ColumnInfo(name = "Name") var name: String?,

    @ColumnInfo(name = "TeamTag") var teamTag: String?

)