
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class FieldCreate : MonoBehaviour
    {
        public Transform baseCube;
        public Transform cubeBorder;
        public Transform scorePanel;
        public TextMesh textScore;
        public Transform[] sphereArray;
        public TextMesh gameOver;
        public int countX;
        public int countY;
        private int[] indexes = new int[3];
        private int positionSphereX;
        private int positionSphereY;
        public int[,] busyArray;
        public Vector3 selectedSphere=new Vector3(-1,-1,-2);
        private int scoreUp = 0;
        private GameObject[] exitButton;
   
    // Start is called before the first frame update

    bool CheckVacant()
        {
            for (int i = 0; i < countX; i++)
            {
                for (int j = 0; j < countY; j++)
                {
                    if (busyArray[i, j] == -1)
                        return true;
                }
            }
            return false;
        }

        void PositionSearch(ref int positionSphereX, ref int positionSphereY)
        {
            if (CheckVacant() == true)
            {
                while (busyArray[positionSphereX, positionSphereY] != -1)
                {
                    positionSphereX = Random.Range(0, countX);
                    positionSphereY = Random.Range(0, countY);

                }
            }
            else GameOver();

        }

        void GameOver()
        {
       
        Instantiate(gameOver, new Vector3(5,6,-5), Quaternion.identity);
       
    }

        public void GenerateSpheres()
        {
          for (int k = 0; k < indexes.Length; k++)
          {
              indexes[k] = Random.Range(0, sphereArray.Length);
              positionSphereX = Random.Range(0, countX);
              positionSphereY = Random.Range(0, countY);
              PositionSearch(ref positionSphereX, ref positionSphereY);
              busyArray[positionSphereX, positionSphereY] = indexes[k];
              Instantiate(sphereArray[indexes[k]], new Vector3(positionSphereX, positionSphereY, -2), Quaternion.identity);
          }
        SearchHorizontalChains();
        SearchVerticalChains();
        SearchDiagonalDownChains();
        SearchDiagonalUpChains();
        }
        void DestroySpheresInChain(int i,int j, int direction, int countSpheresInChain)
        {
        ScoreUp(countSpheresInChain);
         Collider[] hitColliders = Physics.OverlapSphere(new Vector3(i,j,-2), 0.5f);
        foreach (var hitCollider in hitColliders)
        {
            Destroy(hitCollider.gameObject);
        }
        busyArray[i, j] = -1;
        if (direction == 0) //horizontal
           {
            Collider[] hitColliders1 = Physics.OverlapSphere(new Vector3(i+1, j, -2), 0.5f);
            foreach (var hitCollider in hitColliders1)
            {
                Destroy(hitCollider.gameObject);
            }
            busyArray[i + 1, j] = -1;

            Collider[] hitColliders2 = Physics.OverlapSphere(new Vector3(i + 2, j, -2), 0.5f);
            foreach (var hitCollider in hitColliders2)
            {
                Destroy(hitCollider.gameObject);
            }
            busyArray[i + 2, j] = -1;

            Collider[] hitColliders3 = Physics.OverlapSphere(new Vector3(i + 3, j, -2), 0.5f);
            foreach (var hitCollider in hitColliders3)
            {
                Destroy(hitCollider.gameObject);
            }
            busyArray[i + 3, j] = -1;

            Collider[] hitColliders4 = Physics.OverlapSphere(new Vector3(i + 4, j, -2), 0.5f);
            foreach (var hitCollider in hitColliders4)
            {
                Destroy(hitCollider.gameObject);
            }
            busyArray[i + 4, j] = -1;

            if (countSpheresInChain >= 5)
            {
                Collider[] hitColliders5 = Physics.OverlapSphere(new Vector3(i + 5, j, -2), 0.5f);
                foreach (var hitCollider in hitColliders5)
                {
                    Destroy(hitCollider.gameObject);
                }
                busyArray[i + 5, j] = -1;
            }
            if (countSpheresInChain >= 6)
            {
                Collider[] hitColliders6 = Physics.OverlapSphere(new Vector3(i + 6, j, -2), 0.5f);
                foreach (var hitCollider in hitColliders6)
                {
                    Destroy(hitCollider.gameObject);
                }
                busyArray[i + 6, j] = -1;
            }
            if (countSpheresInChain >= 7)
            {
                Collider[] hitColliders7 = Physics.OverlapSphere(new Vector3(i + 7, j, -2), 0.5f);
                foreach (var hitCollider in hitColliders7)
                {
                    Destroy(hitCollider.gameObject);
                }
                busyArray[i + 7, j] = -1;
            }
            if (countSpheresInChain >= 8)
            {
                Collider[] hitColliders8 = Physics.OverlapSphere(new Vector3(i + 8, j, -2), 0.5f);
                foreach (var hitCollider in hitColliders8)
                {
                    Destroy(hitCollider.gameObject);
                }
                busyArray[i + 8, j] = -1;
            }
        }
        if (direction == 1) //vertical
        {
            Collider[] hitColliders1 = Physics.OverlapSphere(new Vector3(i, j + 1, -2), 0.5f);
            foreach (var hitCollider in hitColliders1)
            {
                Destroy(hitCollider.gameObject);
            }
            busyArray[i, j + 1] = -1;

            Collider[] hitColliders2 = Physics.OverlapSphere(new Vector3(i, j + 2, -2), 0.5f);
            foreach (var hitCollider in hitColliders2)
            {
                Destroy(hitCollider.gameObject);
            }
            busyArray[i, j + 2 ] = -1;

            Collider[] hitColliders3 = Physics.OverlapSphere(new Vector3(i, j + 3, -2), 0.5f);
            foreach (var hitCollider in hitColliders3)
            {
                Destroy(hitCollider.gameObject);
            }
            busyArray[i, j + 3] = -1;

            Collider[] hitColliders4 = Physics.OverlapSphere(new Vector3(i, j + 4, -2), 0.5f);
            foreach (var hitCollider in hitColliders4)
            {
                Destroy(hitCollider.gameObject);
            }
            busyArray[i, j + 4] = -1;

            if (countSpheresInChain >= 5)
            {
                Collider[] hitColliders5 = Physics.OverlapSphere(new Vector3(i, j + 5, -2), 0.5f);
                foreach (var hitCollider in hitColliders5)
                {
                    Destroy(hitCollider.gameObject);
                }
                busyArray[i, j + 5] = -1;
            }
            if (countSpheresInChain >= 6)
            {
                Collider[] hitColliders6 = Physics.OverlapSphere(new Vector3(i, j + 6, -2), 0.5f);
                foreach (var hitCollider in hitColliders6)
                {
                    Destroy(hitCollider.gameObject);
                }
                busyArray[i, j + 6] = -1;
            }
            if (countSpheresInChain >= 7)
            {
                Collider[] hitColliders7 = Physics.OverlapSphere(new Vector3(i, j + 7, -2), 0.5f);
                foreach (var hitCollider in hitColliders7)
                {
                    Destroy(hitCollider.gameObject);
                }
                busyArray[i, j + 7] = -1;
            }
            if (countSpheresInChain >= 8)
            {
                Collider[] hitColliders8 = Physics.OverlapSphere(new Vector3(i, j + 8, -2), 0.5f);
                foreach (var hitCollider in hitColliders8)
                {
                    Destroy(hitCollider.gameObject);
                }
                busyArray[i, j + 8] = -1;
            }
        }
        if (direction == 2) //downDiagonal
        {
            Collider[] hitColliders1 = Physics.OverlapSphere(new Vector3(i + 1, j + 1, -2), 0.5f);
            foreach (var hitCollider in hitColliders1)
            {
                Destroy(hitCollider.gameObject);
            }
            busyArray[i + 1, j + 1] = -1;

            Collider[] hitColliders2 = Physics.OverlapSphere(new Vector3(i + 2, j + 2, -2), 0.5f);
            foreach (var hitCollider in hitColliders2)
            {
                Destroy(hitCollider.gameObject);
            }
            busyArray[i + 2, j + 2] = -1;

            Collider[] hitColliders3 = Physics.OverlapSphere(new Vector3(i + 3, j + 3, -2), 0.5f);
            foreach (var hitCollider in hitColliders3)
            {
                Destroy(hitCollider.gameObject);
            }
            busyArray[i + 3, j + 3] = -1;

            Collider[] hitColliders4 = Physics.OverlapSphere(new Vector3(i + 4, j + 4, -2), 0.5f);
            foreach (var hitCollider in hitColliders4)
            {
                Destroy(hitCollider.gameObject);
            }
            busyArray[i + 4, j + 4] = -1;

            if (countSpheresInChain >= 5)
            {
                Collider[] hitColliders5 = Physics.OverlapSphere(new Vector3(i + 5, j + 5, -2), 0.5f);
                foreach (var hitCollider in hitColliders5)
                {
                    Destroy(hitCollider.gameObject);
                }
                busyArray[i + 5, j + 5] = -1;
            }
            if (countSpheresInChain >= 6)
            {
                Collider[] hitColliders6 = Physics.OverlapSphere(new Vector3(i + 6, j + 6, -2), 0.5f);
                foreach (var hitCollider in hitColliders6)
                {
                    Destroy(hitCollider.gameObject);
                }
                busyArray[i + 6, j + 6] = -1;
            }
            if (countSpheresInChain >= 7)
            {
                Collider[] hitColliders7 = Physics.OverlapSphere(new Vector3(i + 7, j + 7, -2), 0.5f);
                foreach (var hitCollider in hitColliders7)
                {
                    Destroy(hitCollider.gameObject);
                }
                busyArray[i + 7, j + 7] = -1;
            }
            if (countSpheresInChain >= 8)
            {
                Collider[] hitColliders8 = Physics.OverlapSphere(new Vector3(i + 8, j + 8, -2), 0.5f);
                foreach (var hitCollider in hitColliders8)
                {
                    Destroy(hitCollider.gameObject);
                }
                busyArray[i + 8, j + 8] = -1;
            }
        }
        if (direction == 3) //upDiagonal
        {
            Collider[] hitColliders1 = Physics.OverlapSphere(new Vector3(i + 1, j - 1, -2), 0.5f);
            foreach (var hitCollider in hitColliders1)
            {
                Destroy(hitCollider.gameObject);
            }
            busyArray[i + 1, j - 1] = -1;

            Collider[] hitColliders2 = Physics.OverlapSphere(new Vector3(i + 2, j - 2, -2), 0.5f);
            foreach (var hitCollider in hitColliders2)
            {
                Destroy(hitCollider.gameObject);
            }
            busyArray[i + 2, j - 2] = -1;

            Collider[] hitColliders3 = Physics.OverlapSphere(new Vector3(i + 3, j - 3, -2), 0.5f);
            foreach (var hitCollider in hitColliders3)
            {
                Destroy(hitCollider.gameObject);
            }
            busyArray[i + 3, j - 3] = -1;

            Collider[] hitColliders4 = Physics.OverlapSphere(new Vector3(i + 4, j - 4, -2), 0.5f);
            foreach (var hitCollider in hitColliders4)
            {
                Destroy(hitCollider.gameObject);
            }
            busyArray[i + 4, j - 4] = -1;

            if (countSpheresInChain >= 5)
            {
                Collider[] hitColliders5 = Physics.OverlapSphere(new Vector3(i + 5, j - 5, -2), 0.5f);
                foreach (var hitCollider in hitColliders5)
                {
                    Destroy(hitCollider.gameObject);
                }
                busyArray[i + 5, j - 5] = -1;
            }
            if (countSpheresInChain >= 6)
            {
                Collider[] hitColliders6 = Physics.OverlapSphere(new Vector3(i + 6, j - 6, -2), 0.5f);
                foreach (var hitCollider in hitColliders6)
                {
                    Destroy(hitCollider.gameObject);
                }
                busyArray[i + 6, j - 6] = -1;
            }
            if (countSpheresInChain >= 7)
            {
                Collider[] hitColliders7 = Physics.OverlapSphere(new Vector3(i + 7, j - 7, -2), 0.5f);
                foreach (var hitCollider in hitColliders7)
                {
                    Destroy(hitCollider.gameObject);
                }
                busyArray[i + 7, j - 7] = -1;
            }
            if (countSpheresInChain >= 8)
            {
                Collider[] hitColliders8 = Physics.OverlapSphere(new Vector3(i + 8, j - 8, -2), 0.5f);
                foreach (var hitCollider in hitColliders8)
                {
                    Destroy(hitCollider.gameObject);
                }
                busyArray[i + 8, j - 8] = -1;
            }
        }
    } //end DestroySpheresInChain

    void SearchHorizontalChains()
        {
        bool flag = false;
        for (int i = 0; i < countX; i++)
        {
            for (int j = 0; j < countY; j++)
            {
               
                if (i + 8 < countX)
                {
                    if (busyArray[i, j] != -1 && busyArray[i, j] == busyArray[i + 1, j] && busyArray[i, j] == busyArray[i + 2, j] && busyArray[i, j] == busyArray[i + 3, j]
                        && busyArray[i, j] == busyArray[i + 4, j] && busyArray[i, j] == busyArray[i + 5, j] && busyArray[i, j] == busyArray[i + 6, j]
                        && busyArray[i, j] == busyArray[i + 7, j] && busyArray[i, j] == busyArray[i + 8, j])
                    {
                        DestroySpheresInChain(i, j, 0, 8);
                        flag = true;

                    }
                }
                if (i + 7 < countX)
                {
                    if (busyArray[i, j] != -1 && busyArray[i, j] == busyArray[i + 1, j] && busyArray[i, j] == busyArray[i + 2, j] && busyArray[i, j] == busyArray[i + 3, j]
                        && busyArray[i, j] == busyArray[i + 4, j] && busyArray[i, j] == busyArray[i + 5, j] && busyArray[i, j] == busyArray[i + 6, j]
                        && busyArray[i, j] == busyArray[i + 7, j])
                    {
                        DestroySpheresInChain(i, j, 0, 7);
                        flag = true;

                    }
                }
                if (i + 6 < countX)
                {
                    if (busyArray[i, j] != -1 && busyArray[i, j] == busyArray[i + 1, j] && busyArray[i, j] == busyArray[i + 2, j] && busyArray[i, j] == busyArray[i + 3, j]
                        && busyArray[i, j] == busyArray[i + 4, j] && busyArray[i, j] == busyArray[i + 5, j] && busyArray[i, j] == busyArray[i + 6, j])
                    {
                        DestroySpheresInChain(i, j, 0, 6);
                        flag = true;

                    }
                }
                if (i + 5 < countX)
                {
                    if (busyArray[i, j] != -1 && busyArray[i, j] == busyArray[i + 1, j] && busyArray[i, j] == busyArray[i + 2, j] && busyArray[i, j] == busyArray[i + 3, j]
                        && busyArray[i, j] == busyArray[i + 4, j] && busyArray[i, j] == busyArray[i + 5, j])
                    {
                        DestroySpheresInChain(i, j, 0, 5);
                        flag = true;

                    }
                }
                if (i + 4 < countX)
                {
                    if (busyArray[i, j] != -1 && busyArray[i, j] == busyArray[i + 1, j] && busyArray[i, j] == busyArray[i + 2, j] && busyArray[i, j] == busyArray[i + 3, j]
                        && busyArray[i, j] == busyArray[i + 4, j])
                    {
                        DestroySpheresInChain(i, j, 0, 4);
                        flag = true;

                    }
                }
                if (flag) break;    
            }
            if (flag) break;
        }

    }
    void SearchVerticalChains()
    {
        bool flag = false;
        for (int i = 0; i < countX; i++)
        {
            for (int j = 0; j < countY; j++)
            {

                if (j + 8 < countY)
                {
                    if (busyArray[i, j] != -1 && busyArray[i, j] == busyArray[i, j + 1] && busyArray[i, j] == busyArray[i, j + 2] && busyArray[i, j] == busyArray[i, j + 3]
                        && busyArray[i, j] == busyArray[i, j + 4] && busyArray[i, j] == busyArray[i, j + 5] && busyArray[i, j] == busyArray[i, j + 6]
                        && busyArray[i, j] == busyArray[i, j + 7] && busyArray[i, j] == busyArray[i, j + 8])
                    {
                        DestroySpheresInChain(i, j, 1, 8);
                        flag = true;

                    }
                }
                if (j + 7 < countY)
                {
                    if (busyArray[i, j] != -1 && busyArray[i, j] == busyArray[i, j + 1] && busyArray[i, j] == busyArray[i, j + 2] && busyArray[i, j] == busyArray[i, j + 3]
                        && busyArray[i, j] == busyArray[i, j + 4] && busyArray[i, j] == busyArray[i, j + 5] && busyArray[i, j] == busyArray[i, j + 6]
                        && busyArray[i, j] == busyArray[i, j + 7] )
                    {
                        DestroySpheresInChain(i, j, 1, 7);
                        flag = true;

                    }
                }
                if (j + 6 < countY)
                {
                    if (busyArray[i, j] != -1 && busyArray[i, j] == busyArray[i, j + 1] && busyArray[i, j] == busyArray[i, j + 2] && busyArray[i, j] == busyArray[i, j + 3]
                        && busyArray[i, j] == busyArray[i, j + 4] && busyArray[i, j] == busyArray[i, j + 5] && busyArray[i, j] == busyArray[i, j + 6])
                    {
                        DestroySpheresInChain(i, j, 1, 6);
                        flag = true;

                    }
                }
                if (j + 5 < countY)
                {
                    if (busyArray[i, j] != -1 && busyArray[i, j] == busyArray[i, j + 1] && busyArray[i, j] == busyArray[i, j + 2] && busyArray[i, j] == busyArray[i, j + 3]
                        && busyArray[i, j] == busyArray[i, j + 4] && busyArray[i, j] == busyArray[i, j + 5])
                    {
                        DestroySpheresInChain(i, j, 1, 5);
                        flag = true;

                    }
                }
                if (j + 4 < countY)
                {
                    if (busyArray[i, j] != -1 && busyArray[i, j] == busyArray[i, j + 1] && busyArray[i, j] == busyArray[i, j + 2] && busyArray[i, j] == busyArray[i, j + 3]
                        && busyArray[i, j] == busyArray[i, j + 4])
                    {
                        DestroySpheresInChain(i, j, 1, 4);
                        flag = true;

                    }
                }
                if (flag) break;
            }
            if (flag) break;
        }

    }
    void SearchDiagonalDownChains()
    {
        bool flag = false;
        for (int i = 0; i < countX; i++)
        {
            for (int j = 0; j < countY; j++)
            {

                if (i + 8 < countX && j + 8 < countY)
                {
                    if (busyArray[i, j] != -1 && busyArray[i, j] == busyArray[i + 1, j + 1] && busyArray[i, j] == busyArray[i + 2, j + 2] && busyArray[i, j] == busyArray[i + 3, j + 3]
                        && busyArray[i, j] == busyArray[i + 4, j + 4] && busyArray[i, j] == busyArray[i + 5, j + 5] && busyArray[i, j] == busyArray[i + 6, j + 6]
                        && busyArray[i, j] == busyArray[i + 7, j + 7] && busyArray[i, j] == busyArray[i + 8, j + 8])
                    {
                        DestroySpheresInChain(i, j, 2, 8);
                        flag = true;

                    }
                }
                if (i + 7 < countX && j + 7 < countY)
                {
                    if (busyArray[i, j] != -1 && busyArray[i, j] == busyArray[i + 1, j + 1] && busyArray[i, j] == busyArray[i + 2, j + 2] && busyArray[i, j] == busyArray[i + 3, j + 3]
                        && busyArray[i, j] == busyArray[i + 4, j + 4] && busyArray[i, j] == busyArray[i + 5, j + 5] && busyArray[i, j] == busyArray[i + 6, j + 6]
                        && busyArray[i, j] == busyArray[i + 7, j + 7] )
                    {
                        DestroySpheresInChain(i, j, 2, 7);
                        flag = true;

                    }
                }
                if (i + 6 < countX && j + 6 < countY)
                {
                    if (busyArray[i, j] != -1 && busyArray[i, j] == busyArray[i + 1, j + 1] && busyArray[i, j] == busyArray[i + 2, j + 2] && busyArray[i, j] == busyArray[i + 3, j + 3]
                        && busyArray[i, j] == busyArray[i + 4, j + 4] && busyArray[i, j] == busyArray[i + 5, j + 5] && busyArray[i, j] == busyArray[i + 6, j + 6])
                    {
                        DestroySpheresInChain(i, j, 2, 6);
                        flag = true;

                    }
                }
                if (i + 5 < countX && j + 5 < countY)
                {
                    if (busyArray[i, j] != -1 && busyArray[i, j] == busyArray[i + 1, j + 1] && busyArray[i, j] == busyArray[i + 2, j + 2] && busyArray[i, j] == busyArray[i + 3, j + 3]
                        && busyArray[i, j] == busyArray[i + 4, j + 4] && busyArray[i, j] == busyArray[i + 5, j + 5])
                    {
                        DestroySpheresInChain(i, j, 2, 5);
                        flag = true;

                    }
                }
                if (i + 4 < countX && j + 4 < countY)
                {
                    if (busyArray[i, j] != -1 && busyArray[i, j] == busyArray[i + 1, j + 1] && busyArray[i, j] == busyArray[i + 2, j + 2] && busyArray[i, j] == busyArray[i + 3, j + 3]
                        && busyArray[i, j] == busyArray[i + 4, j + 4] )
                    {
                        DestroySpheresInChain(i, j, 2, 4);
                        flag = true;

                    }
                }
                if (flag) break;
            }
            if (flag) break;
        }

    }

    void SearchDiagonalUpChains()
    {
        bool flag = false;
        for (int i = 0; i < countX; i++)
        {
            for (int j = countY-1; j >=0; j--)
            {

                if (i + 8 < countX && j - 8 >= 0)
                {
                    if (busyArray[i, j] != -1 && busyArray[i, j] == busyArray[i + 1, j - 1] && busyArray[i, j] == busyArray[i + 2, j - 2] && busyArray[i, j] == busyArray[i + 3, j - 3]
                        && busyArray[i, j] == busyArray[i + 4, j - 4] && busyArray[i, j] == busyArray[i + 5, j - 5] && busyArray[i, j] == busyArray[i - 6, j + 6]
                        && busyArray[i, j] == busyArray[i + 7, j - 7] && busyArray[i, j] == busyArray[i + 8, j - 8])
                    {
                        DestroySpheresInChain(i, j, 3, 8);
                        flag = true;

                    }
                }
                if (i + 7 < countX && j - 7 >= 0)
                {
                    if (busyArray[i, j] != -1 && busyArray[i, j] == busyArray[i + 1, j - 1] && busyArray[i, j] == busyArray[i + 2, j - 2] && busyArray[i, j] == busyArray[i + 3, j - 3]
                        && busyArray[i, j] == busyArray[i + 4, j - 4] && busyArray[i, j] == busyArray[i + 5, j - 5] && busyArray[i, j] == busyArray[i + 6, j - 6]
                        && busyArray[i, j] == busyArray[i + 7, j - 7])
                    {
                        DestroySpheresInChain(i, j, 3, 7);
                        flag = true;

                    }
                }
                if (i + 6 < countX && j - 6 >= 0)
                {
                    if (busyArray[i, j] != -1 && busyArray[i, j] == busyArray[i + 1, j - 1] && busyArray[i, j] == busyArray[i + 2, j - 2] && busyArray[i, j] == busyArray[i + 3, j - 3]
                        && busyArray[i, j] == busyArray[i + 4, j - 4] && busyArray[i, j] == busyArray[i + 5, j - 5] && busyArray[i, j] == busyArray[i + 6, j - 6])
                    {
                        DestroySpheresInChain(i, j, 3, 6);
                        flag = true;

                    }
                }
                if (i + 5 < countX && j - 5 >= 0)
                {
                    if (busyArray[i, j] != -1 && busyArray[i, j] == busyArray[i + 1, j - 1] && busyArray[i, j] == busyArray[i + 2, j - 2] && busyArray[i, j] == busyArray[i + 3, j - 3]
                        && busyArray[i, j] == busyArray[i + 4, j - 4] && busyArray[i, j] == busyArray[i + 5, j - 5])
                    {
                        DestroySpheresInChain(i, j, 3, 5);
                        flag = true;

                    }
                }
                if (i + 4 < countX && j - 4 >= 0)
                {
                    if (busyArray[i, j] != -1 && busyArray[i, j] == busyArray[i + 1, j - 1] && busyArray[i, j] == busyArray[i + 2, j - 2] && busyArray[i, j] == busyArray[i + 3, j - 3]
                        && busyArray[i, j] == busyArray[i + 4, j - 4] )
                    {
                        DestroySpheresInChain(i, j, 3, 4);
                        flag = true;

                    }
                }
                if (flag) break;
            }
            if (flag) break;
        }

    }
    void ScoreUp(int countSpheresInChain)
    {
        if (countSpheresInChain == 4) scoreUp += 3;
        if (countSpheresInChain == 5) scoreUp += 5;
        if (countSpheresInChain == 6) scoreUp += 7;
        if (countSpheresInChain == 7) scoreUp += 10;
        if (countSpheresInChain == 8) scoreUp += 15;
        var textObject =GameObject.FindWithTag("ScoreText");
        
         textObject.GetComponent<TextMesh>().text= scoreUp.ToString();
 
    }
    public void Restart()
    {
        var objects = GameObject.FindGameObjectsWithTag("Cube");
        foreach (var o in objects)
        {
            Destroy(o.gameObject);
        }
        var objects2 = GameObject.FindGameObjectsWithTag("Sphere");
        foreach (var o in objects2)
        {
            Destroy(o.gameObject);
        }
        var objects3 = GameObject.FindGameObjectsWithTag("ScoreText");
        foreach (var o in objects3)
        {
            Destroy(o.gameObject);
        }
        var objects4 = GameObject.FindGameObjectsWithTag("GameOver");
        foreach (var o in objects4)
        {
            Destroy(o.gameObject);
        }
        Start();
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    void Start()
        {
            /*exitButton = GameObject.FindGameObjectsWithTag("ExitButton");
            foreach (var o in exitButton)
            {
               o.gameObject.SetActive(false);
            }*/
                    
            busyArray = new int[countX, countY];
            for (int i = 0; i < countX; i++)
            {
                for (int j = 0; j < countY; j++)
                {
                    busyArray[i, j] = -1;
                }
            }

            GenerateSpheres();
           
            transform.position = new Vector3(countX / 2.0f, countY / 2.0f, -10);
            for (int i = 0; i < countX; i++)
            {
                for (int j = 0; j < countY; j++)
                {
                    Instantiate(baseCube, new Vector3(i, j, -1), Quaternion.identity);
                    Instantiate(cubeBorder, new Vector3(i, j, 0), Quaternion.identity);
                }
            }
            //Instantiate(scorePanel, new Vector3(countX / 2.0f, countY, 0), Quaternion.identity);
             Instantiate(textScore, new Vector3((countX-1) / 2.0f, countY+2, 0), Quaternion.identity);
            
    }


}
