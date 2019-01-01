/*var apiUrl = "https://localhost:44375/api/";

var app = new Vue({
        el: '#app',
        data: {
            message: 'Creating Quiz ... ',
            quizzes: null,
            questions: null,
            answers: null,
            isReadOnly: true,
            isEdit: true
        },
        created: function() {
            var self = this;
            //todo go back to overview or somthing
        },
        methods: {
            save: function ()
            {
                var self = this;

/*            // de properties authorId en publisherId van het Book zijn nog leeg
            // de vue.js databinding vult enkel de compositeproperties author en publisher
            self.currentBook.authorId = self.currentBook.author.id;
            self.currentBook.publisherId = self.currentBook.publisher.id;#1#

                // opslaan - ajax configuratie
                var ajaxHeaders = new Headers();
                ajaxHeaders.append("Content-Type", "application/json");
                var ajaxConfig = {
                    method: 'POST',
                    body: JSON.stringify(self.currentBook),
                    headers: ajaxHeaders
                };
                let myRequest = new Request(`${apiURL}Quiz/`, ajaxConfig);
                fetch(myRequest)
                    .then(res => res.json())
                    .then(res => {
                        self.addQuizToList(res);
                    })
                    .catch(err => console.error('Fout: Quiz/ajaxconfig ' + err));

            },
            addQuizToList: function (quiz) {

                self.currentQuiz.id = quiz.id;
                self.books.push(quiz);
                self.fetchQuizDetails(self.quiz[self.quiz.length - 1]);
            },
        }

    }
);*/