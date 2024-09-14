using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordDistributor : MonoBehaviour
{
    [SerializeField] StringSet[] stringSets;

    void Awake()
    {
        stringSets[0].strings = new string[] {"UG", "UC"};
        stringSets[1].strings = new string[] {"122", "CSD", "CMU", "ABP", "SCS", "CFA", "MCS"};
        stringSets[2].strings = new string[] {"WEAN", "BOSS", "MSSM", "CIAO", "ROHR", "HUNT"};
        stringSets[3].strings = new string[] {"CYERT", "SCOTT", "SMITH", "CLYDE", "MUDGE", "WELCH", "ALUMS", "BELLA", "DEFER", "HUNAN", "ANSYS"};
        stringSets[4].strings = new string[] {"ALUMNI", "BRAMER", "PORTER", "POSNER", "WARNER", "DONNER", "MCGILL", "RESNIK", "STEVER", "MACKEY", "15-112", "15-122", "15-359", "15-151", "15-659", "TUTORS", "15-418", "MELLON", "KOSBIE", "21-127", "SCHATZ"};
        stringSets[5].strings = new string[] {"DOHERTY", "THE HUB", "SCOBELL", "FREW ST", "TECH ST", "HARDEST", "PURNELL", "LAPRIMA", "ENTROPY", "REDHAWK", "STACKD"};
        stringSets[6].strings = new string[] {"CARNEGIE", "ART PARK", "MOREWOOD", "CLYDE ST", "HENRY ST", "SCIENCES", "MATRICES", "CALCULUS", "TOP-TIER", "CARNEGIE", "BOOTCAMP", "SUCCEEDS", "RIGOROUS", "MILLIES", "SCOTTYS", "WILDBLUE"};
    }
}
