/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package myExtPackage;

import com.smartfoxserver.v2.entities.Room;
import com.smartfoxserver.v2.entities.User;
import com.smartfoxserver.v2.entities.Zone;
import com.smartfoxserver.v2.entities.data.ISFSObject;
import com.smartfoxserver.v2.extensions.BaseClientRequestHandler;
import java.util.List;
import java.util.Random;

/**
 *
 * @author Hassan Ali Khan
 */
public class SomeNumberHandle extends BaseClientRequestHandler{

    @Override
    public void handleClientRequest(User user, ISFSObject isfso) {
       // throw new UnsupportedOperationException("Not supported yet.");
       trace("WOrking");
       float varX,varY, varZ;
        String name ;
        
        
        
        float randomNumberx = (float) ((new Random().nextInt(60) + 10));
        float randomNumberz = (float) ((new Random().nextInt(40) + 10));
        varX = randomNumberx;
        varY = 0;
        varZ = randomNumberz;
        isfso.putFloat("varX", varX);
        isfso.putFloat("varY", varY);
        isfso.putFloat("varZ", varZ);
        
       isfso.putInt("userID", user.getId());
        
    // send("SpawnNewPlayer",isfso,user);
       // name = isfso.getUtfString("name");
        //send("SpawnNewPlayer", isfso, user);
        Zone zone = user.getZone();
       
       Room room = zone.getRoomByName("The Game");
        String zonename = room.getName();
      // Room room= user.();
       List<User> usrList = room.getUserList();
     
    // 
        send("SpawnNewPlayer", isfso, usrList);
    
    }
    
}
