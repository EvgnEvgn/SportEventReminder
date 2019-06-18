package com.sharipov.app.db.entity

import androidx.annotation.NonNull
import androidx.room.ColumnInfo
import androidx.room.Entity
import androidx.room.PrimaryKey

@Entity(tableName = "Area")
class Area(

    @NonNull @PrimaryKey(autoGenerate = true) var id: Long? = null,

    @ColumnInfo(name = "Name") var name: String,

    @ColumnInfo(name = "ParentArea") var parentArea: String

)