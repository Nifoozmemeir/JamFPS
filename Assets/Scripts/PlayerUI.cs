using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    
    [SerializeField] protected Image ValueEnergyJetPack;
    [SerializeField] protected Image IconEnergyJetPack;
    [SerializeField] protected Sprite JampOn;
    [SerializeField] protected Sprite JampOff;
    protected bool isAlertFlag;
    protected float blinkInterval;
    protected float blinkTimer;

    [SerializeField] protected TextMeshProUGUI MessagePrimary;
    [SerializeField] protected float maxTimeWatch;
    protected float currentTimeWatch;
    [SerializeField] protected TextMeshProUGUI MessageStage;
    [SerializeField] protected TextMeshProUGUI MessageDeath;
    [SerializeField] protected TextMeshProUGUI MessageKills;
    private void Start()
    {
        isAlertFlag = false;
        IconEnergyJetPack.sprite = JampOn;
        blinkInterval = 0.5f;
        blinkTimer = 0f;
        currentTimeWatch = 0f;
    }

    private void Update()
    {
        if(currentTimeWatch < maxTimeWatch)
        {
            currentTimeWatch += Time.deltaTime;
        }
        else
        {
            this.MessagePrimary.text = "";
        }
        if (isAlertFlag)
        {
            BlinkJetPack();
        }
        else
        {
            Color newColor = ValueEnergyJetPack.color;
            newColor.a = 1f;
            ValueEnergyJetPack.color = newColor;
        }
    }
    public void UpdateEnergyPack(float value, bool flag)
    {
        this.ValueEnergyJetPack.fillAmount = value;
        if (flag != isAlertFlag)
        {
            isAlertFlag = flag;
            IconEnergyJetPack.sprite = (
                   IconEnergyJetPack.sprite == JampOff
               ) ? JampOff : JampOn;
        }
    }

    public void UpdateMesagge(string value)
    {
        this.MessagePrimary.text = value;
        currentTimeWatch = 0;
    }
    public void UpdateStage(string value)
    {
        this.MessageStage.text = "Stage: " + value;
    }
    public void UpdateDeath(int value)
    {
        this.MessageDeath.text = "Death: " + value;
    }
    public void UpdateKills(int value)
    {
        this.MessageKills.text = "Kills: " + value;
    }
    public void BlinkJetPack()
    {
        
        blinkTimer += Time.deltaTime;

        if (blinkTimer >= blinkInterval)
        {                
            blinkTimer = 0f;
            Color newColor = ValueEnergyJetPack.color;
            newColor.a = 1f;
            ValueEnergyJetPack.color = newColor;
        }
        else
        {
            Color newColor = ValueEnergyJetPack.color;
            newColor.a -= blinkTimer;
            ValueEnergyJetPack.color = newColor;
        }
       
    }
}
