function popup(score, maxScore) {
    // Get the <span> element that closes the modal
    var span = document.getElementsByClassName("close")[0];
    var modal = document.getElementById('myModal');
    var scoreboard = document.getElementById("scoreBoard");
    scoreboard.innerHTML = "Your score is " + score + "/" + maxScore;

    // When the user clicks on <span> (x), close the modal
    span.onclick = function() {
        modal.style.display = "none";
    };

    // When the user clicks anywhere outside of the modal, close it
    window.onclick = function(event) {
        if (event.target === modal) {
            modal.style.display = "none";
        }
    };
    modal.style.display = "block";
}

function validateQuiz() {
    document.getElementById("answer").onclick = validate;
    var maxScore = document.getElementsByName("question").length;
    var score = 0;

    for (var i = 0; i < maxScore; i++) {
        var isCorrect = false;
        var questionElement = "input" + i;
        var checkboxes = document.getElementsByName(questionElement);
        var currentQuestionSpan = document.getElementById(i + " span");

        for (var counter = 0; counter < checkboxes.length; counter++) {
            if (checkboxes[counter].value === "on" && checkboxes[counter].checked === true) {
                isCorrect = false;
                break;
            }
            if (checkboxes[counter].checked && (checkboxes[counter].value === "value")) {
                isCorrect = true;
            }
        }
        if (isCorrect) {
            score++;
            currentQuestionSpan.innerHTML = "Correct";
            currentQuestionSpan.style.color = '#3c7d3e';
        } else {
            document.getElementById(i + " span").innerHTML = "Wrong";
            currentQuestionSpan.style.color = '#ff0000';
        }
        popup(score, maxScore);
    }
}