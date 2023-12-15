using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CakeController : MonoBehaviour
{
     bool isCollide, isFluidCollide, isCooked, isSmashed, isColored, isCreamed, isPackaged;
     Transform gameObjectToLead;

     [SerializeField] Transform CakeHolder;
     [SerializeField] Transform Dough;
     [SerializeField] Transform CookedCake;
     [SerializeField] Transform HeartCake;
     [SerializeField] Transform cake;
     [SerializeField] Transform Cream;
     [SerializeField] Transform Package;

     [SerializeField] Material HeartCakeMaterial;
     // Start is called before the first frame update
     void Start()
     {
          isCollide = false;
          isFluidCollide = false;
          isCooked = false;
          isSmashed = false;
          isColored = false;
          isCreamed = false;
          isPackaged = false;
          Dough.gameObject.SetActive(false);
          CookedCake.gameObject.SetActive(false);
          HeartCake.gameObject.SetActive(false);
          Cream.gameObject.SetActive(false);
          Package.gameObject.SetActive(false);
     }

     // Update is called once per frame
     void Update()
     {
          if (isCollide)
          {
               transform.position += new Vector3(0, 0, -gameObjectToLead.GetComponent<PlayerController>().ballSpeed * Time.deltaTime);
               transform.position = new Vector3(gameObjectToLead.GetComponent<PlayerController>().newX, transform.position.y, transform.position.z);
          }


     }

     private void OnTriggerEnter(Collider collision)
     {
           if ((collision.transform.tag == "Player" || collision.transform.tag == "Cake") & !isCollide)
          {
               isCollide = true;

               gameObjectToLead = collision.transform;


          }

          if ((collision.transform.tag == "Fluid" ) & !isFluidCollide)
          {
               isFluidCollide = true;

               Dough.gameObject.SetActive(true);
          }

          if ((collision.transform.tag == "Cook") & !isCooked)
          {
               isCooked = true;

               CakeHolder.gameObject.SetActive(false);
               Dough.gameObject.SetActive(false);
               CookedCake.gameObject.SetActive(true);
          }

          if ((collision.transform.tag == "Smash") & !isSmashed)
          {
               isSmashed = true;


               CookedCake.gameObject.SetActive(false);
               HeartCake.gameObject.SetActive(true);
          }

          if ((collision.transform.tag == "PinkFluid") & !isColored)
          {
               
               isColored = true;

               cake.gameObject.GetComponent<MeshRenderer>().material.color = HeartCakeMaterial.color;

               
          }

          if ((collision.transform.tag == "Cream") & !isCreamed)
          {
               isCreamed = true;

               Cream.gameObject.SetActive(true);
          }

          if ((collision.transform.tag == "Package") & !isPackaged)
          {
               isPackaged = true;

               Package.gameObject.SetActive(true);
          }
     }
}
