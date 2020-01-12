package com.unityapi.backend;

import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

@RestController
@RequestMapping(path = "highScore")
public class HighScore {

    @GetMapping(path = "/getScore")
    public HighScoreModal getHighScoreDetails(){

        HighScoreModal obj = new HighScoreModal("John", 115);
        return obj;
    }
}
