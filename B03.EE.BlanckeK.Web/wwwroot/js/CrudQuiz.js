var getDetailApiUrl = "https://localhost:44342/api/Quiz/@Model.Id";
var app = new Vue({
    el: '#app',
    data: {
        message: 'Editing Quiz ... ',
        questionList: [],
        question: null,
        currentQuiz: [],
        isReadOnly: true,
        isEdit: true
    },
    created: function () {
        var self = this;
        self.fetchQuizDetails();
    },
    methods:
    {
        save: function ()
        {
            // this is the main function to save a complete quiz
            var self = this;
            var apiUrl = "https://localhost:44342/api/";

            var ajaxHeaders = new Headers();
            ajaxHeaders.append("Content-Type", "application/json");

            var ajaxConfig =
            {
                method: 'PUT',
                body: JSON.stringify(self.currentQuiz),
                headers: ajaxHeaders
            };
            let myRequest = new Request(`${apiUrl}Quiz/${self.currentQuiz.id}`, ajaxConfig);
            fetch(myRequest)
                .then(res => res.json())
                .catch(err => console.error('Fout: fetch(myrequest) ' + err))
                // after we updated the quiz we delete the old questions
                .then(function ()
                {
                    self.DeleteOldQuestions(self.currentQuiz.id);
                })
                // if the old questions are deleted we add the new questions
                .then(function ()
                {
                    self.saveQuestions(self.currentQuiz.id);
                });
        },
        DeleteOldQuestions: function (quizId)
        {
            if (quizId === undefined) return;
            // first delete all the old questions for the current quiz
            var apiDeleteQuestionsUrl = "https://localhost:44342/api/questions/quiz/" + quizId;

            var ajaxHeaders = new Headers();
            var ajaxConfig =
            {
                method: 'DELETE',
                headers: ajaxHeaders
            };
            let myRequest = new Request(apiDeleteQuestionsUrl, ajaxConfig);
            fetch(myRequest);
        },
        saveQuestions: function (quizId)
        {
            // define a new empty array and fill it with the contents of the questionText label
            // and add the correct quizId and an empty answerlist then push all the arrays of questions 
            // to the questionList
            var questionList = [];
            $("input[id=question]").each(function () {
                var answerlist = [];
                var questionText = $(this).val();

                this.question = {};
                this.question["answerList"] = answerlist;
                this.question["questionText"] = questionText;
                this.question["quizId"] = quizId;

                questionList.push(this.question);
            });

            ajaxHeaders = new Headers();
            ajaxHeaders.append("Content-Type", "application/json");
            ajaxConfig =
                {
                    method: 'PUT',
                    body: JSON.stringify(questionList),
                    headers: ajaxHeaders
                };
            myRequest = new Request("https://localhost:44342/api/questions/quiz/" + quizId, ajaxConfig);
            fetch(myRequest);
        },

        DeleteQuestion: function (questionId) {

        },
        AddQuestion: function () {

        },
        // here we get the current quiz details

        fetchQuizDetails: function () {
            var self = this;
            if (!self.isReadOnly) return;
            fetch(getDetailApiUrl)
                .then(res => res.json())
                .then(function (res) {
                    self.currentQuiz = res;
                })
                .catch(err => console.error('Fout: FecthQuizDetails ' + err));
        }
    }
}
);
Vue.config.devtools = true;