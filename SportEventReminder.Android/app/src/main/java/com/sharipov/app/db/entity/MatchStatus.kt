package com.sharipov.app.db.entity

import com.google.gson.annotations.SerializedName

enum class MatchStatus(var id: Int) {

    @SerializedName("0")
    Unknown(0),

    @SerializedName("1")
    Scheduled(1),

    @SerializedName("2")
    Canceled(2),

    @SerializedName("3")
    Postponed(3),

    @SerializedName("4")
    Suspended(4),

    @SerializedName("5")
    InPlay(5),

    @SerializedName("6")
    Paused(6),

    @SerializedName("7")
    Finished(7),

    @SerializedName("8")
    Awarded(8);

}