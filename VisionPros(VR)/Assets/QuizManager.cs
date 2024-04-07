using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuizManager : MonoBehaviour
{
    public List<QuestionAndAnswers> QnA;
    public GameObject[] options;
    public int currentQuestionIndex = 0; // Initialize current question index
    public Text QuestionTxt;
    public GameObject correctPanel;
    public GameObject wrongPanel;
    public float displayDuration = 5f;

    void Start()
    {
        geenrateQuestion();
    }

    public void Correct()
    {
        currentQuestionIndex++; // Move to the next question index

        if (currentQuestionIndex < 10) // Check if it's within the question limit
        {
            geenrateQuestion();
        }
        else
        {
            Debug.Log("Quiz completed!");
            // Handle end of the quiz (e.g., show final score, reset game, etc.)
        }
    }

    void SetAnswers()
    {
        for (int i = 0; i < options.Length; i++)
        {
            options[i].GetComponent<AnswerScript>().isCorrect = false;
            options[i].transform.GetChild(0).GetComponent<Text>().text = QnA[currentQuestionIndex].Answers[i];
            if (QnA[currentQuestionIndex].CorrectAnswer == i + 1)
            {
                options[i].GetComponent<AnswerScript>().isCorrect = true;
            }
        }
    }

    void geenrateQuestion()
    {
        QuestionTxt.text = QnA[currentQuestionIndex].Question;
        SetAnswers();
    }

    public void ShowCorrectPanel()
    {
        correctPanel.SetActive(true);
        wrongPanel.SetActive(false);
    }

    public void ShowWrongPanel()
    {
        wrongPanel.SetActive(true);
        correctPanel.SetActive(false);

        StartCoroutine(DisplayCorrectAnswer(QnA[currentQuestionIndex -1]));
    }

    private IEnumerator DisplayCorrectAnswer(QuestionAndAnswers question)
    {
        Text correctAnswerText = wrongPanel.transform.Find("Corrected Answer Text").GetComponent<Text>();
        correctAnswerText.text = "Correct Answer: " + question.Answers[question.CorrectAnswer - 1];

        yield return new WaitForSeconds(displayDuration);

        wrongPanel.SetActive(false);
    }
}
