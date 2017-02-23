/**
 * Attribute
 *
 * Storing other detailed attributes within this class will make things neater. Attributes will be used to determine
 * other statuses like physical resistance and magical resistance.
 * 
**/

public class Attribute{
    private Dexterity dexterity;
    private Intelligence intelligence;
    private Strength strength;
    private Vitality vitality;

    public Attribute(float _dex, float _int, float _str, float _vit) {
        this.dexterity = new Dexterity(_dex);
        this.intelligence = new Intelligence(_int);
        this.strength = new Strength(_str);
        this.vitality = new Vitality(_vit);
    }

}
