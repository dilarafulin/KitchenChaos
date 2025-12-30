using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlatesCounter : BaseCounter
{
    public event EventHandler OnPlateSpawned;
    public event EventHandler OnPlateRemoved;

    [SerializeField] private KitchenObjectSO plateKitchenObjectSO;


    private float spawnPlateTimerMax = 4f;
    private float spawnPlateTimer;
    private int plateSpawnedAmount;
    private int plateSpawnedAmountMax = 4; 


    private void Update()
    {
        spawnPlateTimer += Time.deltaTime;
        if(spawnPlateTimer > spawnPlateTimerMax)
        {
            spawnPlateTimer = 0f;

            if(GameManager.Instance.IsGamePlaying() && plateSpawnedAmount < plateSpawnedAmountMax)
            {
                plateSpawnedAmount++; 

                OnPlateSpawned?.Invoke(this,EventArgs.Empty);
            }
        }
       
    }

    public override void Interact(Player player)
    {
        if(!player.HasKitchenObject())
        //playerin eli bos 
        { 
            if(plateSpawnedAmount > 0)
            {
                plateSpawnedAmount--;

                KitchenObject.SpawnKitchenObject(plateKitchenObjectSO, player);

                OnPlateRemoved?.Invoke(this,EventArgs.Empty);
            }
        
        }
    }
}
