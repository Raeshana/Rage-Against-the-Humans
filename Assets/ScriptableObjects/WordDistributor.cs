using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordDistributor : MonoBehaviour
{
    [SerializeField] StringSet[] stringSets;

    void Awake()
    {
        stringSets[0].strings = new string[] {"UG", "UC", "TP"};
        stringSets[1].strings = new string[] {'SCS', 'CSD', 'PHP', 'MCS', '122', 'CMU', 'SFS', 'CFA', 'ABP'};
        stringSets[2].strings = new string[] {'ROHR', 'CIAO', 'C0VM', 'BOMB', 'MSSM', 'HUNT', 'WEAN', 'CLAC', 'TBUF', 'BOSS'};
        stringSets[3].strings = new string[] {'ANSYS', 'MUDGE', 'SMITH', 'DEFER', 'ALUMS', 'BELLA', 'HUNAN', 'CLYDE', 'SCOTT', 'CYERT', 'WELCH'}
        stringSets[5].strings = new string[] {'BRAMER', 'POSNER', 'MCGILL', 'STACKD', '15-151', 'PORTER', 'TUTORS', '21-127', '15-418', 'SCHATZ', '15-112', 'STEVER', 'RESNIK', '15-122', '15-659', 'MELLON', 'MACKEY', 'DONNER', 'KOSBIE', '15-359', 'WARNER', 'ALUMNI'};
        stringSets[6].strings = new string[] {'MILLIES', 'REDHAWK', 'SCOTTYS', 'THE HUB', 'ENTROPY', 'LAPRIMA', 'TECH ST', 'DOHERTY', 'HARDEST', 'FREW ST', 'SCOBELL', 'PURNELL'};
    }
}
