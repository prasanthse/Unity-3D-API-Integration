package com.unityapi.backend;

public class HighScoreModal {

    private String playerName;
    private int highScore;

    public HighScoreModal(String playerName, int highScore) {
        this.playerName = playerName;
        this.highScore = highScore;
    }

    public String getPlayerName() {
        return playerName;
    }

    public int getHighScore() {
        return highScore;
    }
}
