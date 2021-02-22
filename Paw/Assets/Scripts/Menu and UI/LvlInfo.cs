using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class LvlInfo
{
    // === Переменные уровня ===
    [Header("Идентификатор уровня (ОБЯЗАТЕЛЬНО)")]
    public string Lvl_ID;  // Если не заполнять - игра не пустит на уровень
    [Header("Наименование уровня (для игрока)")]
    public string Lvl_Name;
    [Header("Задания на уровень")]
    public LvlTask[] Lvl_Tasks;
    [Header("Пройден уровень?")]
    public bool isLvlFinished;
    [Header("Будем проходить на HungerCore или нет?")]
    public bool isHungerCore;

    // === Переменные игрока на уровне ===
    [Header("Мировая позиция игрока по очкам за уровень")]
    public int Player_WorldBestPosition;
    [Header("Максимум набранных очков за уровень за всю игру")]
    public int Player_MaxGainedScore;
    [Header("Количество набранных очков за последнее прохождение")]
    public int Player_LastGainedScore;
}
