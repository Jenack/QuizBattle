using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class GameManager : MonoBehaviour {

    public Question[] questions;
    private static List<Question> _unanwseredQuestions;

    private Question _currentQuestion;


    void Start()
    {
        if (_unanwseredQuestions == null || _unanwseredQuestions.Count == 0)
        {
            _unanwseredQuestions = questions.ToList<Question>();
        }

        GetRandomQuestion();
        Debug.Log(_currentQuestion.fact + " is " +_currentQuestion.isTrue);

    }

    void GetRandomQuestion()
    {
        int randomQuestionIndex = Random.Range(0, _unanwseredQuestions.Count);
        _currentQuestion = _unanwseredQuestions[randomQuestionIndex];

        _unanwseredQuestions.RemoveAt(randomQuestionIndex);
    }

}
