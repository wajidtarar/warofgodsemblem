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
public class UpdateLocations extends BaseClientRequestHandler{
    
   @Override
    public void handleClientRequest(User user, ISFSObject isfso) {
       // throw new UnsupportedOperationException("Not supported yet.");
      
      /* float varX,varY, varZ;
        String name ;
        
        
        
        float randomNumber = (float) ((new Random().nextInt(90) + 10));
        varX = randomNumber;
        varY = 0;
        varZ = randomNumber;
        
        
        
        isfso.putFloat("varX", isfso.getFloat("varX"));
        isfso.putFloat("varY", 0);
        isfso.putFloat("varZ", isfso.getFloat("varZ"));
     
        name = isfso.getUtfString("name");*/
        //send("SpawnNewPlayer", isfso, user);
        Zone zone = user.getZone();
        Room room = zone.getRoomByName("The Game");
        List<User> usrList = room.getPlayersList();
        for (int x=0;x<usrList.size();x++) {
            trace(usrList.get(x).getId());
        }
        send("newlocs", isfso, usrList);
    }
    
}
