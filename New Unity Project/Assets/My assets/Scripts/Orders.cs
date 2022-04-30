using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orders : MonoBehaviour
{
    [SerializeField] List<GameObject> paperSizes;
    [SerializeField] List<Color> paperColour;

    int difficulty;
    int complexity;
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetInt("difficulty") != 0 ) 
        {
            difficulty = PlayerPrefs.GetInt("difficulty");
        }
        if (PlayerPrefs.GetInt("complexity") != 0)
        {
            complexity = PlayerPrefs.GetInt("complexity");
        }
        int numOrders = Random.Range(0, difficulty);
        order[] orders = new order[numOrders];
        for(int i = 0; i<= orders.Length; i++) 
        {
            orders[i] = makeRandomOrder(complexity);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public struct order
    {
        //Variable declaration
        public bool Complete;
        public string Name;
        public page[] Pages;

        public order(bool complete, string name, page[] pages)
        {
            this.Complete = complete;
            this.Name = name;
            this.Pages = pages;
        }
    }
    
    public struct page 
    {
        public int PageNo;
        public int Size;
        public bool Scanned;
        public Color Colour;
        
        public page(int pageNo, int size, Color colour, bool scanned)
        {
            this.PageNo = pageNo;
            this.Size = size;
            this.Colour = colour;
            this.Scanned = scanned;
        }
    }

    public order makeOrder(bool complete, string name, page[] pages)
    {
        order order = new order(complete, name, pages);
        return order;
    }
    public order makeRandomOrder(int complexity)
    {
        order order = new order();
        order.Complete = false;
        order.Name = makeOrderName();
        order.Pages = makePages(complexity);
        return order;
    }
    public page[] makePages(int numPages) 
    {
        page[] pages = new page[numPages];
        for(int i = 0; i <= numPages; i++) 
        {
            pages[i] = makePage(i);
        }
        return null;
    }
    public page makePage(int num) 
    {
        page page = new page();
        page.PageNo = num;
        page.Size = Random.Range(1, 4);
        page.Scanned = false;
        int colour = Random.Range(0, 4);
        switch (colour)
        {
            case 0:
                page.Colour = Color.white;
                break;
            case 1:
                page.Colour = Color.red;
                break;
            case 2:
                page.Colour = Color.blue;
                break;
            case 3:
                page.Colour = Color.green;
                break;
        }

        return page;
    }
    private string makeOrderName()
    {
        string characters = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789abcdefghijklmnopqrstuvwxyz0123456789";
        var nameString = new char[6];

        for (int i = 0; i < nameString.Length; i++)
        {
            nameString[i] = characters[Random.Range(0, characters.Length)];
        }
        return nameString.ToString();
    }
    
}
